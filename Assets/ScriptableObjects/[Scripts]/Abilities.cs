using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Ability")]
public class Abilities : ScriptableObject
{
    [Tooltip("Name of the ability in the game")]
    public string abilityName;
    [Tooltip("How many uses the abilty has before needing to be recharged")]
    public int maxUses;
    [Tooltip("If the ability does direct damage.")]
    public bool doesDamage;
    [Tooltip("How much damage the ability does base.")]
    public float damage;
    [Tooltip("If the ability should use accuracy")]
    public bool canMiss;
    [Range(0.0f, 100.0f), Tooltip("How likely the ability is too hit, 100 is always")]
    public float accuracy;
    [Tooltip("What does the ability target")]
    public TargetingTypes targets;

    [Header("Secondary Effects")]
    [Tooltip("Any none damaging effects of the ability")]
    public FullEffectCluster effects;
}

[System.Serializable]
public class FullEffectCluster
{
    [Description("Clusters are for effects that will happen together or not at all, example: an attack heals and increases damage 30% of the time.")]
    [Tooltip("The status effects of the ability")]
    public List<StatusEffects> statusEffects;
    [Tooltip("The stat changing effects of the ability")]
    public List<StatChange> statChangeEffects;

    [Range(0.0f, 100.0f), Tooltip("The change the effects happen")]
    public float effectChance;
}

[System.Serializable]
public class StatusEffects
{
    [Tooltip("The effect type")]
    public Status status;
}

[System.Serializable]
public class StatChange
{
    [Tooltip("The stat this ability effects")]
    public Stats stat;
    [Tooltip("The way in which the ability changes")]
    public StatChangeMethod method;
    [Tooltip("How much the ability changes it by")]
    public float changeAmount;
}