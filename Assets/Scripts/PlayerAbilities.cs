using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public Animator anim;

    public TMP_Text button1;
    public TMP_Text button2;
    public TMP_Text button3;
    public TMP_Text button4;

    public string Ability1Name;
    public string Ability2Name;
    public string Ability3Name;
    public string Ability4Name;

    private void Start()
    {
        button1.text = Ability1Name;
        button2.text = Ability2Name;
        button3.text = Ability3Name;
        button4.text = Ability4Name;
    }

    public void OnButton1Pressed()
    {
        anim.SetTrigger("Ability1");
    }

    public void OnButton2Presed()
    {
        anim.SetTrigger("Ability2");
    }

    public void OnButton3Pressed()
    {
        anim.SetTrigger("Ability3");
    }

    public void OnButton4Pressed()
    {
        anim.SetTrigger("Ability4");
    }
}
