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

    public Abilities slotAbility;

    public int usesUsed;
    public void SetUpSlot(Abilities inputAbility, int uses)
    {
        slotAbility = inputAbility;
        usesUsed = uses;

        UpdateSlot();
    }

    public void UpdateSlot()
    {
        slotName.text = slotAbility.abilityName;
        slotUses.text = usesUsed.ToString() + " / " + slotAbility.maxUses;
        if (slotAbility.canMiss)
        {
            slotAccuracy.text = slotAbility.accuracy.ToString();
        }
        else
        {
            slotAccuracy.text = "--";
        }
        if (slotAbility.doesDamage == true) 
        {
            slotDamage.text = slotAbility.damage.ToString();
        }
        else 
        {
            slotDamage.text = "--";
        }
    }

    public void OnSlotPressed()
    {
        usesUsed--;

    }
}
