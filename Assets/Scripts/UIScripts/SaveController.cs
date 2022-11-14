using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public static SaveController instance;

    static string defaultSavesPath = Application.dataPath + "/saves.txt";

    Vector3 PlayerStartPosition;

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

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(0);

        try
        {

            StreamReader sr = new StreamReader(defaultSavesPath);

            if (sr == null)
            {
                Debug.LogError("can't open file");
                return;
            }

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                char[] sperators = new char[] { ',' };
                string[] values = line.Split(sperators, StringSplitOptions.RemoveEmptyEntries);

                Debug.Log(values);

                PlayerStartPosition = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
            }

            sr.Close();

        }
        catch
        {

        }
    }

    public void SaveGame()
    {
        StreamWriter sw = new StreamWriter(defaultSavesPath);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        string line = player.transform.position.x + "," + player.transform.position.y + "," + player.transform.position.z;

        sw.WriteLine(line);

        sw.Close();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0); //scene 0 is the overworld
        PlayerStartPosition = Vector3.zero;
    }

    public Vector3 GetStartPosition()
    {
        return PlayerStartPosition; 
    }
}
