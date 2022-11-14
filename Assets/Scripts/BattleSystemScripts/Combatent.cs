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

    [Header("Combatent visuals")]
    public Animator combatentAnims;
    public Slider HealthBar;
    public TMP_Text HealthText;

    [Header("Combatent Abilities")]
    public List<AbilityCombined> activeAbilities;
    public Abilities chosenAbility;

    protected void Start()
    {
        chosenAbility = null;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        HealthBar.value = currentHealth / maxHealth;
        HealthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}

[System.Serializable]
public class AbilityCombined
{
    public Abilities ability;
    public int usesUsed;
}
