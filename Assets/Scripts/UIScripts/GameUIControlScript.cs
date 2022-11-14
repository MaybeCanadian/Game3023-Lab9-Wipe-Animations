using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIControlScript : MonoBehaviour
{
    public void OnSaveButtonPressed()
    {
        SaveController.instance.SaveGame();
    }

    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene(2); // 2 is main menu
    }
}
