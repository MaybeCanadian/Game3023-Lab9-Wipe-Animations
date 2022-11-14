using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScreenNonDupeScript : MonoBehaviour
{
    public static BattleScreenNonDupeScript instance;

    private void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
