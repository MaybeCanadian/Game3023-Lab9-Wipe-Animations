using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public Animator anim;

    public AbilitySlotScript button1;
    public AbilitySlotScript button2;
    public AbilitySlotScript button3;
    public AbilitySlotScript button4;

    public string Ability1Name;
    public string Ability2Name;
    public string Ability3Name;
    public string Ability4Name;

    private void Start()
    {
        //button1.text = Ability1Name;
        //button2.text = Ability2Name;
        //button3.text = Ability3Name;
        //button4.text = Ability4Name;
    }
}
