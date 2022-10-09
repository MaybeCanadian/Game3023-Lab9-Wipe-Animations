using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounterScript : MonoBehaviour
{
    public bool isWalking = false;
    private PlayerController playerController;

    public float encounterChance = 20.0f;
    public float encounterCheckRate = 0.2f;
    public bool encounterCoolDown = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        isWalking = false;
        encounterCoolDown = false;
        MainSceneManager.instance.AddObject(gameObject);
    }

    private void Update()
    {
        isWalking = playerController.GetIsWalking();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Grass" && isWalking && !encounterCoolDown)
        {
            float randomEncounterChance = UnityEngine.Random.Range(0, 100);

            encounterCoolDown = true;

            Invoke("ResetCoolDown", encounterCheckRate);

            if(randomEncounterChance <= encounterChance)
            {
                SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
            }
            else
            {
                //Debug.Log("no encounter");
            }
        }
    }


    private void ResetCoolDown()
    {
        encounterCoolDown = false;
    }
}
