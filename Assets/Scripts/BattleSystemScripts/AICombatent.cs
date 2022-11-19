using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AICombatent : Combatent
{
    public Enemies enemyBlock;
    public Image enemyImage;

    private void Awake()
    {
        enemyBlock = EncounterManager.instance.GetEnemyEncounter();

        if (enemyBlock)
        {
            List<Abilities> abilities = enemyBlock.GetAbilities();
            activeAbilities.Clear();

            foreach (Abilities ability in abilities)
            {
                AbilityCombined tempAbil = new AbilityCombined();
                tempAbil.ability = ability;
                tempAbil.usesUsed = 0;
                activeAbilities.Add(tempAbil);
            }

            stats = enemyBlock.stats;

            enemyImage.sprite = enemyBlock.image;
            combatentName = enemyBlock.name;
        }
    }

    
    public override void OnTurnStart(Combatent input)
    {

    }
    public override void OnTurnEnd(Combatent input)
    {

    }
    public override void OnAllFightersAdded()
    {
        ChooseAbilityRandom();
    }
    public override void OnRoundEnd() 
    {
        //when the round ends the AI chooses a new move to use
        //Debug.Log("test");
        ChooseAbilityRandom();
    }
    private void ChooseAbilityRandom()
    { 
        //just randomly chooses one of the abilities
        if (activeAbilities.Count > 0)
        {
            chosenAbility = activeAbilities[Random.Range(0, activeAbilities.Count - 1)].ability;
            ChooseAbility(chosenAbility);
        }
    }
}
