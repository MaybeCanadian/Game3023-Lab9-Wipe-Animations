using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New encounterList", menuName = "Areas/Encounters")]
public class PossibleEnemies : ScriptableObject
{
    public List<Enemies> allEnemies;

    public Enemies GetEncounter()
    {
        if (allEnemies.Count == 0)
            return null;


        int random = Random.Range(0, allEnemies.Count);

        return allEnemies[random];
    }
}
