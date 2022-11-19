using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy", menuName = "Fighters/Enemy")]
public class Enemies : ScriptableObject
{
    [Header("Enemy Information")]
    public string displayName = "";
    public Sprite image;

    [Header("Enemy Stats")]
    public StatBlock stats;

    [Header("Enemy Abilities")]
    public Abilities ability1;
    public Abilities ability2;
    public Abilities ability3;
    public Abilities ability4;

    [Header("AI tags")]
    public Factions team;
    public List<FightingStyles> fightingStyles;

    private List<Abilities> abilities;
    private bool abilitiesSetUp = false;

    public List<Abilities> GetAbilities()
    {
        if(abilitiesSetUp == false)
        {
            abilities = new List<Abilities>();
            SetUpAbilities(ability1);
            SetUpAbilities(ability2);
            SetUpAbilities(ability3);
            SetUpAbilities(ability4);

            abilitiesSetUp = true;
        }
        return abilities;
    }
    private void SetUpAbilities(Abilities ability)
    {
        if(ability != null)
        {
            abilities.Add(ability);
        }
    }
}

[System.Serializable]
public enum Factions
{
    HEROES,
    VILLAGER,
    BANDITS
}

[System.Serializable]
public enum FightingStyles
{
    NEUTRAL,
    RANDOM,
    AGGRESIVE,
    DEFENSIVE,
    HEALER
}
