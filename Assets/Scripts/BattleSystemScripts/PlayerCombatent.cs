using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatent : Combatent
{
    [Header("Player Input UI")]
    public GameObject actionButtonsParent;
    public GameObject playerAbilityPanel;
    public GameObject abilityChosenPanel;
    public List<AbilitySlotScript> abilitySlots;

    private PlayerCombatStates oldState;

    private new void Start()
    {
        oldState = PlayerCombatStates.NULL;
        ChangePlayerCombatState(PlayerCombatStates.ChooseAction);

        SetUpSlots();

        base.Start();
    }

    private void SetUpSlots()
    {
        int itt = 0;
        foreach (AbilitySlotScript slot in abilitySlots)
        {
            if (activeAbilities.Count >= itt)
            {
                slot.SetUpSlot(activeAbilities[itt]);
            }

            itt++;
        }
    }

    private void UpdateAllSlots()
    {
        foreach(AbilitySlotScript slot in abilitySlots)
        {
            slot.UpdateSlot();
        }
    }

    public void ChangePlayerCombatState(PlayerCombatStates newState)
    {

        if(oldState == newState)
        {
            return;
        }

        switch(oldState)
        {
            case PlayerCombatStates.NULL:
                actionButtonsParent?.SetActive(false);
                playerAbilityPanel?.SetActive(false);
                abilityChosenPanel?.SetActive(false);
                break;
            case PlayerCombatStates.ChooseAction:
                actionButtonsParent?.SetActive(false);
                break;
            case PlayerCombatStates.ChooseAbility:
                playerAbilityPanel?.SetActive(false);
                break;
            case PlayerCombatStates.WaitForOpponent:
                abilityChosenPanel?.SetActive(false);
                break;
            case PlayerCombatStates.Fleeing:
                //nothing
                break;
        }

        if(newState != PlayerCombatStates.NULL)
            switch(newState)
        {
            case PlayerCombatStates.ChooseAction:
                actionButtonsParent?.SetActive(true);
                break;
            case PlayerCombatStates.ChooseAbility:
                playerAbilityPanel?.SetActive(true);
                break;
            case PlayerCombatStates.WaitForOpponent:
                abilityChosenPanel?.SetActive(true);
                break;
            case PlayerCombatStates.Fleeing:
                //nothing for now
                break;
        }

        oldState = newState;

        return;
    }

    public void OnAbilityChosen(Abilities ability)
    {
        chosenAbility = ability;
        ChangePlayerCombatState(PlayerCombatStates.WaitForOpponent);
    }

    public void OnAbilityActionPressed()
    {
        ChangePlayerCombatState(PlayerCombatStates.ChooseAbility);
    }

    public void OnAbilityBackButtonPressed()
    {
        ChangePlayerCombatState(PlayerCombatStates.ChooseAction);
    }

    public void OnWaitingCancelButtonPressed()
    {
        foreach(AbilityCombined abilities in activeAbilities)
        {
            if(chosenAbility == abilities.ability)
            {
                
                abilities.usesUsed--;
                break;
            }
        }

        UpdateAllSlots();
        chosenAbility = null;
        ChangePlayerCombatState(PlayerCombatStates.ChooseAbility);
    }

    public void OnFleeActionPressed()
    {
        BattleManager.instance.Flee(); //for now just flees
        ChangePlayerCombatState(PlayerCombatStates.Fleeing);
    }

}

public enum PlayerCombatStates
{
    NULL,
    ChooseAction,
    ChooseAbility,
    WaitForOpponent,
    Fleeing
}
