using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Created in 02/05/2020 by Zijie Zhang

//---<Purpose>---
//Script that manages Sniffind objs
//---</Purpose>---
//---<LOGS>---

//02/05/2020
//Created basic features
//---</LOGS>---

//---<Bugs or Questions in Mind>---
public class Sniffind_Manager : MonoBehaviour
{

    public static GameObject[] Website_Arrays; //every websites
    public static GameObject Search_ResultArea; //area that shows search result
    public static GameObject Website_Area; //area that shows website
    private bool opened = false; //if this app is opened
    private int i = 0;
    private void Awake()
    {
        Website_Arrays = Resources.LoadAll("Prefabs/Sniffind/Websites", typeof(GameObject)).Cast<GameObject>().ToArray(); //Load every website into the array
        Search_ResultArea = transform.Find("Result_Area").Find("Scroll View").Find("Viewport").Find("Content").gameObject; 
        Website_Area = transform.Find("Result_Area").gameObject; //Initialize
        foreach (GameObject website in Sniffind_Manager.Website_Arrays)
        {

            GameObject obj = Instantiate(website, Sniffind_Manager.Website_Area.transform);
            obj.transform.localScale = new Vector3(0, 0, 0);
            Website_Arrays[i] = obj;
            i++;
           
        }
    }

    private void Update()
    {
    }
    public void on_Click() //function when clicked on the icon
    {
        if (opened)
        {
            this.transform.localScale = new Vector3(0, 0, 0);
            opened = false;
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            opened = true;
        }
    }
}
