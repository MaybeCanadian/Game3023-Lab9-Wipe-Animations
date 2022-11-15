using System;
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
        ChangePlayerCombatState(PlayerCombatStates.WaitingToStart);

        SetUpSlots();

        base.Start();
    }

    //Battle system events------------------------------------------
    public override void OnTurnStart(Combatent input)
    { 
        //event when a turn starts

        if(input == this)
        {
            //event when the player turn starts
        }
    }
    public override void OnTurnEnd(Combatent input)
    {
        //event when a turn ends.
        if(input == this)
        {
            //this is when the player turn ends
        }
    }
    public override void OnAllFightersAdded()
    {
        //called when all starting combatents are added
        ChangePlayerCombatState(PlayerCombatStates.ChooseAction);
    }
    public override void OnRoundEnd()
    {
        //called when the round ends, ie when all combatents have gone.
        chosenAbility = null;
        ChangePlayerCombatState(PlayerCombatStates.ChooseAction);
    }
    //---------------------------------------------------------------
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

            case PlayerCombatStates.WaitingToStart:
                //nothing
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

            case PlayerCombatStates.WaitingToStart:
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
    public new void OnAbilityChosen(Abilities ability)
    {
        chosenAbility = ability;
        base.OnAbilityChosen(ability);
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
        RefundAbilityUse(chosenAbility);
        chosenAbility = null;
        UnChooseAbilty();
        ChangePlayerCombatState(PlayerCombatStates.ChooseAbility);
    }
    private void RefundAbilityUse(Abilities ability)
    {
        foreach (AbilityCombined abilities in activeAbilities)
        {
            if (chosenAbility == abilities.ability)
            {
                abilities.usesUsed--;
                break;
            }
        }

        UpdateAllSlots();
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
    WaitingToStart,
    ChooseAction,
    ChooseAbility,
    WaitForOpponent,
    Fleeing
}
