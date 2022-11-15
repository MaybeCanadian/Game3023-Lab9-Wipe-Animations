using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombatent : Combatent
{
    public override void OnTurnStart(Combatent input)
    {

    }
    public override void OnTurnEnd(Combatent input)
    {

    }
    public override void OnAllFightersAdded()
    { 
        //some basic code to chose a random ability, only has one called debug ability
        if (activeAbilities.Count > 0)
        {
            chosenAbility = activeAbilities[Random.Range(0, activeAbilities.Count - 1)].ability;
            ChooseAbility(chosenAbility);
        }
    }
    public override void OnRoundEnd() { }
}
