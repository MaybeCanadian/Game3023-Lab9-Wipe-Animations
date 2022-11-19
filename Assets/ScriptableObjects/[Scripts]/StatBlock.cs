using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New StatBlock", menuName = "Fighters/StatBlock")]
public class StatBlock : ScriptableObject
{
    [Header("Health")]
    [Min(0.0f)]
    public float maxHealth;
    [Min(0.0f)]
    public float healthRegen;
    [Header("Attack")]
    [Min(0.0f)]
    public float physicalDamage;
    [Min(0.0f)]
    public float magicalDamage;
    public List<ExtraElementalValues> additionalElementalDamages;
    [Header("Defense")]
    [Min(0.0f)]
    public float physicalDefense;
    [Min(0.0f)]
    public float magicalDefense;
    public List<ExtraElementalValues> additionalElementalDefenses;
    [Header("Movement")]
    [Min(0.0f)]
    public float speed;
}

[System.Serializable]
public class ExtraElementalValues
{
    public ElementalDamage damageType;
    public float amount;
}

[System.Serializable]
public enum ElementalDamage
{
    FIRE,
    ICE,
    ELECTRIC,
    DARK,
    LIGHT
}
