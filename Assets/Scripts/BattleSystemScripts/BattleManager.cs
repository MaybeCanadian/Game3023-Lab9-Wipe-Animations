using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    private MainSceneManager manager;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        manager = MainSceneManager.instance;

        if (manager)
        {
            manager.PauseScene();
        }
    }

    public void Flee()
    {
        if (manager)
        {
            MainSceneManager.instance.UnPauseScene();
            SceneManager.UnloadSceneAsync("Battle");
        }
        else
        {
            Application.Quit();
        }
    }
}
