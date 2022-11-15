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
        if(activeAbilities.Count > 0)
            chosenAbility = activeAbilities[Random.Range(0, activeAbilities.Count - 1)].ability;
    }
    public override void OnRoundEnd() { }
}
