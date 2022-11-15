using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum TargetingTypes
{
    Single,
    AllEnemies,
    Self,
    Ally,
    Team,
    All,
    Across,
    Field,
    None
} //ability targets

[System.Serializable]
public enum StatusApplicationTypes
{
    Apply,
    Remove,
    Protect,
    Weakness
} //Add, remove

[System.Serializable]
public enum Stats
{
    PhysicalDamage, //increases damage to attacks tagged as physical
    MagicDamage, //increase damage to attacks tagged as magical
    PhysicalDefence, //reduces damage from attacks tagged as physical
    MagicDefence, //reduce damage from attacks tagged as magical
    Acuracy, //increases chance to hit
    Dodge //decreases opponent chance to hit you
} //All stat types

[System.Serializable]
public enum StatChangeMethod
{
    Add,
    Subtract,
    Multiply,
    Divide,
    Reset
} //How the stat is changed

[System.Serializable]
public enum AnimationsEnum
{
    SPIN,
    DODGE,
    JUMP,
    ATTACK
}
