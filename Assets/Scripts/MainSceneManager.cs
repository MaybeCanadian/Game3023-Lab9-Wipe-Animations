using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public static MainSceneManager instance { get; private set; } = null;

    List<GameObject> sceneObjects;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        sceneObjects = new List<GameObject>();
        
    }

    public void PauseScene()
    {
        foreach(GameObject gObject in sceneObjects)
        {
            gObject.SetActive(false);
        }
    }
    public void UnPauseScene()
    {
        foreach(GameObject gObject in sceneObjects)
        {
            gObject?.SetActive(true);  
        }
    }

    public void AddObject(GameObject gObject)
    {
        sceneObjects.Add(gObject);
    }

    public bool RemoveObject(GameObject gObject)
    {
        return sceneObjects.Remove(gObject);
    }
}
