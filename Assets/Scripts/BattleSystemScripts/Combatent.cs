using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Combatent : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Animator combatentAnims;
    public Slider HealthBar;
    public TMP_Text HealthText;
    public List<Abilities> activeAbilities;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        HealthBar.value = currentHealth / maxHealth;
        HealthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
