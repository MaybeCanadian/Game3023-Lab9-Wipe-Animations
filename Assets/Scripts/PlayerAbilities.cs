using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public Button ability1;
    public Button ability2;
    public Button ability3;
    public Button ability4;

    public Animator anim;

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
