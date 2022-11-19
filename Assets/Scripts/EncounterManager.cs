using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public static EncounterManager instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public PossibleEnemies possibleEncounters;

    public Enemies GetEnemyEncounter()
    {
        return possibleEncounters.GetEncounter();
    }
}
