using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created in 09/26/2019 by Zijie Zhang

//---<Purpose>---
//To change the mouse script when it hovers sth
//---</Purpose>---
//---<LOGS>---

//10/01/2019
//Created for sentences in clickable points

//01/16/2020
//Only for testing purpose

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class button_Text : MonoBehaviour
{
    private Queue<string> Sentences;

    private void Start()
    {
        Sentences = new Queue<string>();
    }
}
