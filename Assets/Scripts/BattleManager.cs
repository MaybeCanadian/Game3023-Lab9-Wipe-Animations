using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public GameObject abilitiesPanel;
    public bool abilityOpen;

    private void Start()
    {
        abilityOpen = false;
        MainSceneManager.instance.PauseScene();
    }

    public void OnFleePressed()
    {
        MainSceneManager.instance.UnPauseScene();
        SceneManager.UnloadSceneAsync("Battle");
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
