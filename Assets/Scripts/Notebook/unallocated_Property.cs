using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Created in 11/05/2019 by Zijie Zhang

//---<Purpose>---
//The purpose of this script is to create basic for unallocated keywords
//---</Purpose>---

//---<LOGS>---

//11/05/2019
//Created for unallocated keywords storage

//01/10/2019
//This script is not in used.


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class unallocated_Property : MonoBehaviour
{
    //enum{ Adjectives, };
    public string Character_Name; 
    public string Keyword;
    public bool allocated;
    public GameObject Reference_Gameobjects; //reference to gameobjects for deletion
    public string inner_Text;
    

    private void Awake()
    {
        allocated = false;
        Reference_Gameobjects = this.gameObject;
    }
}
