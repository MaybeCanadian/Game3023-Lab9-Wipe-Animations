using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    private void Start()
    {
        MainSceneManager.instance.PauseScene();
    }

    public void OnFleePressed()
    {
        MainSceneManager.instance.UnPauseScene();
        SceneManager.UnloadSceneAsync("Battle");
    }
}
