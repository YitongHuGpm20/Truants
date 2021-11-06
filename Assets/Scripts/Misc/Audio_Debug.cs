using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created in 12/01/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to find all gameobjects that used audios source
//---</Purpose>---

//---<LOGS>---
//12/01/2019
//Added functions

//01/08/2019
//This script is not in used.
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---

public class Audio_Debug : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> sound_Array;
    private void Awake()
    {
        foreach(AudioSource temp in Object.FindObjectsOfType<AudioSource>())
        {
            sound_Array.Add(temp.gameObject);
        }
    }
}
