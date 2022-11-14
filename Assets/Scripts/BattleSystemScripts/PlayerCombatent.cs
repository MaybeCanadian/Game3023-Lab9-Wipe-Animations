using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatent : Combatent
{
    [Header("Player Input UI")]
    public GameObject actionButtonsParent;
    public GameObject playerAbilityPanel;
    public List<AbilitySlotScript> abilitySlots;

    private new void Start()
    {
        actionButtonsParent.SetActive(true);
        playerAbilityPanel.SetActive(false);
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

    public void OnAbilityActionPressed()
    {
        actionButtonsParent.SetActive(false);
        playerAbilityPanel.SetActive(true);
    }

    public void OnAbilityBackButtonPressed()
    {
        playerAbilityPanel.SetActive(false);
        actionButtonsParent.SetActive(true);
    }

    public void OnFleeActionPressed()
    {
        BattleManager.instance.Flee();
    }

}
