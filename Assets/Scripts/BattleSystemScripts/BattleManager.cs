using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    private MainSceneManager manager;

    [Header("Battle system variables")]
    [Tooltip("How long between ticks in seconds")]
    public float tickRate = 0.2f;

    //Events-----------------------------------------------------------------
    public delegate void TurnStart(Combatent currentTurn);
    public static TurnStart OnTurnStart; //called when the turn starts for a combatent
    public delegate void TurnEnd(Combatent currentTurn);
    public static TurnEnd OnTurnEnd; //called when turn ends for a combatent
    public delegate void AllFightersAdded();
    public static AllFightersAdded OnAllFightersAdded; //called after all fighters have been added at the start
    public delegate void RoundEnd();
    public static RoundEnd OnRoundEnd;
    //-----------------------------------------------------------------------

    [Header("Fighters in Battle")]
    public List<Fighter> fighters;

    public List<Fighter> turnOrder;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        manager = MainSceneManager.instance;

        if (manager)
        {
            manager.PauseScene();
        }

        StartCoroutine("MainBattleLoop");
    }

    public void AddFighter(Combatent fighter)
    {
        Fighter tempFighter = new Fighter(fighter);
        tempFighter.Activate();
        fighters.Add(tempFighter);
    }
    public bool RemoveFighter(Combatent fighter)
    {
        foreach(Fighter fig in fighters)
        {
            if(fig.fighter == fighter)
            {
                fighters.Remove(fig);
                return true;
            }
        }

        return false;
    }
    public IEnumerator MainBattleLoop()
    {
        yield return new WaitForEndOfFrame();

        OnAllFightersAdded?.Invoke();

        while(true)
        {
            bool WaitingForInputs = false;

            while (WaitingForInputs == false)
            {
                WaitingForInputs =  CheckCombatentsReady(out int NumReady);
                //Debug.Log(NumReady);
                yield return null;
            }
            
            DetermineTurnOrder();

            DisplayMoves();

            OnRoundEnd?.Invoke();

            ResetFightersAfterRound();

            yield return null;
        }

        //yield break;
    }
    public bool CheckCombatentsReady(out int NumReady)
    {
        NumReady = 0;
        foreach(Fighter fig in fighters)
        {
            if(fig.chosen)
            {
                NumReady++;
            }
        }

        return (NumReady == fighters.Count) ? true : false;
    }
    public void Flee()
    {
        if (manager)
        {
            MainSceneManager.instance.UnPauseScene();
            SceneManager.UnloadSceneAsync("Battle");
        }
        else
        {
            Application.Quit();
        }
    }
    public void DetermineTurnOrder()
    {
        foreach(Fighter fig in fighters)
        {
            fig.inTurnOrder = false;
        }

        Fighter tempStorage = null;
        bool notDone = true;
        while (notDone)
        {
            tempStorage = null;
            foreach (Fighter fig in fighters)
            {
                if (fig.inTurnOrder)
                    continue;

                if(tempStorage == null)
                {
                    tempStorage = fig;
                    continue;
                }

                if (fig.fighter.speed >= tempStorage.fighter.speed)
                {
                    if(fig.fighter.speed == tempStorage.fighter.speed)
                    {
                        tempStorage = (Random.Range(0, 2) == 0) ? fig: tempStorage;
                        continue;
                    }

                    tempStorage = fig;
                    continue;
                }
            }

            if(tempStorage != null)
            {
                tempStorage.inTurnOrder = true;
                turnOrder.Add(tempStorage);
            }
            else
            {
                notDone = false;
            }
        }
    }
    private void DisplayMoves()
    {
        Debug.Log("the moves are");
        while (turnOrder.Count > 0)
        {
            Fighter front = turnOrder[0];
            OnTurnStart?.Invoke(front.fighter);
            Debug.Log(front.fighter.combatentName + " used " + front.fighter.chosenAbility.abilityName);
            OnTurnEnd?.Invoke(front.fighter);
            turnOrder.RemoveAt(0);
        }
    }

    private void ResetFightersAfterRound()
    {
        foreach(Fighter fig in fighters)
        {
            fig.inTurnOrder = false;
            fig.chosen = false;
        }
    }
}



[System.Serializable]
public class Fighter
{
    [Tooltip("The combatent in the fight")]
    public Combatent fighter;
    [Tooltip("If the combatent has chosen an input")]
    public bool chosen;
    public bool inTurnOrder;

    //constructor, makes the fighter with a combatent, we need one to make this class
    public Fighter(Combatent input)
    {
        fighter = input;
        chosen = false;
        inTurnOrder = false;
    }

    //connects the Fighter class to the combatent events-------
    public void Activate()
    {
        fighter.OnAbilityChosen += OnAbilityChosen;
    }
    public void DeActivate()
    {
        fighter.OnAbilityChosen -= OnAbilityChosen;
    }
    //---------------------------------------------------------

    //recieves the ability chosen event from the combatent
    public void OnAbilityChosen(bool input)
    {
        chosen = input;
    }
    public void ResetChosen()
    {
        chosen = false;
    }
}
