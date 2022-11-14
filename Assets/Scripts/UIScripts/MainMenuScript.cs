using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void OnNewGameButtonPressed()
    {
        SaveController.instance.NewGame();
    }
    public void OnLoadButtonPressed()
    {
        SaveController.instance.LoadGame();
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    public void OnCreditsButtonPressed()
    {
        Debug.Log("me");
    }
}
