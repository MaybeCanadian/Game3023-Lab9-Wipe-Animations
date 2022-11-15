using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Combatent : MonoBehaviour
{
    [Header("Combatent Values")]
    public float maxHealth;
    public float currentHealth;
    public float speed;

    [Header("Combatent visuals")]
    public Animator combatentAnims;
    public Slider healthBar;
    public TMP_Text healthText;
    public string combatentName;

    [Header("Combatent Abilities")]
    public List<AbilityCombined> activeAbilities;
    public Abilities chosenAbility;

    public delegate void AbilityChosen(bool input);
    public AbilityChosen OnAbilityChosen;

    //connected the combatent to the battle system events
    protected void OnEnable()
    {
        BattleManager.OnTurnStart += OnTurnStart;
        BattleManager.OnTurnEnd += OnTurnEnd;
        BattleManager.OnAllFightersAdded += OnAllFightersAdded;
    }
    protected void OnDisable()
    {
        BattleManager.OnTurnStart -= OnTurnStart;
        BattleManager.OnTurnEnd -= OnTurnEnd;
        BattleManager.OnAllFightersAdded -= OnAllFightersAdded;
    }
     
    protected void Start()
    {
        chosenAbility = null;
        currentHealth = maxHealth;
        UpdateHealthBar();

        BattleManager.instance.AddFighter(this);
    }
    public void UpdateHealthBar()
    {
        HealthBar.value = currentHealth / maxHealth;
        HealthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
    public void ChooseAbility(Abilities chosen)
    {
        OnAbilityChosen?.Invoke(true);
    }
    public void UnChooseAbilty()
    {
        chosenAbility = null;
        OnAbilityChosen?.Invoke(false);
    }

    //empty functions for the child classes to use, connected to the battle system-----
    public virtual void OnTurnStart(Combatent input) { }
    public virtual void OnTurnEnd(Combatent input) { }
    public virtual void OnAllFightersAdded() { }
    public virtual void OnRoundEnd() { }

    //----------------------------------------------------------------------------------
}

[System.Serializable]
public class AbilityCombined
{
    public Abilities ability;
    public int usesUsed;
}
