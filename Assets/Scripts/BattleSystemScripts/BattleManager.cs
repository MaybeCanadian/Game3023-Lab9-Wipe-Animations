using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public GameObject abilitiesPanel;
    public bool abilityOpen;

    private MainSceneManager manager;

    private void Start()
    {
        abilityOpen = false;

        manager = MainSceneManager.instance;

        if (manager)
        {
            manager.PauseScene();
        }
    }

    public void OnFleePressed()
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

    public void OnAbilityPressed()
    {
        if(abilityOpen)
        {
            abilityOpen=false;
            abilitiesPanel.SetActive(false);
        }
        else
        {
            abilitiesPanel.SetActive(true);
            abilityOpen=true;
        }
    }
}
