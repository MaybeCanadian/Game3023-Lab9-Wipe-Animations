using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilitySlotScript : MonoBehaviour
{
    public TMP_Text slotName;
    public TMP_Text slotUses;
    public TMP_Text slotDamage;
    public TMP_Text slotAccuracy;

    public AbilityCombined slotAbility;
    public void SetUpSlot(AbilityCombined inputAbility)
    {
        slotAbility = inputAbility;

        UpdateSlot();
    }

    public void UpdateSlot()
    {
        slotName.text = slotAbility.ability.abilityName;

        UpdateAccuracy();
        UpdateDamage();
        UpdateUses();  
    }

    private void UpdateDamage()
    {
        if (slotAbility.ability.doesDamage == true)
        {
            slotDamage.text = slotAbility.ability.damage.ToString();
        }
        else
        {
            slotDamage.text = "--";
        }
    }

    private void UpdateAccuracy()
    {
        if (slotAbility.ability.canMiss)
        {
            slotAccuracy.text = slotAbility.ability.accuracy.ToString();
        }
        else
        {
            slotAccuracy.text = "--";
        }
    }

    private void UpdateUses()
    {
        slotUses.text = (slotAbility.ability.maxUses - slotAbility.usesUsed).ToString() + " / " + slotAbility.ability.maxUses;
    }

    public void OnSlotPressed()
    {
        if (slotAbility.usesUsed < slotAbility.ability.maxUses)
        {
            slotAbility.usesUsed++;
            UpdateUses();
        }
        else
        {
            Debug.Log("Out of uses");
        }
    }
}
