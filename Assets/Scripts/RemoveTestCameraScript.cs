using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTestCameraScript : MonoBehaviour
{
    public static RemoveTestCameraScript instance;

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
}
