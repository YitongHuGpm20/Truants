using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 02/05/2020 by Zijie Zhang

//---<Purpose>---
//Having it manage the websites and its properties
//---</Purpose>---
//---<LOGS>---

//02/05/2020
//Created basic features

//---</LOGS>---

//---<Bugs or Questions in Mind>---
public class Website_Manager : MonoBehaviour
{

    public string Search_Title; //the title of the website
    [TextArea(4, 4)]
    public string Search_Content; //the searched content of the website
    public string message;
    private bool opened = false;

    private void Awake()
    {
        //Search_ResultPrefab = Resources.Load<GameObject>("Prefabs/Sniffind/Search_ResultPrefab");
        //Search_ResultPrefab.transform.Find("Search_ResultPrefab").Find("Title").GetComponent<Button>().onClick.AddListener(() => Show_Websites_Onclick());
    }

    private void setups()
    {
        //if (Search_Title != "")
            //Search_ResultPrefab.transform.Find("Title").gameObject.GetComponent<Text>().text = Search_Title;
        //if (Search_Content!="")
            //Search_ResultPrefab.transform.Find("Content").gameObject.GetComponent<Text>().text = Search_Content + "...";
    }

    public void Show_Websites_Onclick()
    {
        //if (!opened)
        //{//if not instaniate before{
        //    //Instantiate(this, Sniffind_Manager.Website_Area.transform); //click to open this website
        //    this.transform.localScale = new Vector3(0, 0, 0);
        //    Debug.Log("initialize");
        //}
        //else
        //{
            //this.transform.localScale = new Vector3(1, 1, 1);
            //Debug.Log("open");

    }

    public void Hide_Websites_Onclick() //hide it when not clicked
    {
        this.transform.localScale = new Vector3(0, 0, 0);
    }

    public void Visage_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(2);
        Component[] temp = Gameobj_Manager.Canvas.transform.Find("Desktop1/WindowArea/").GetComponentsInChildren(typeof(VisageProfile), true);
        foreach (VisageProfile vs in temp)
            vs.CloseProfile();
    }
    public void JoyAun_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(2);
        Component[] temp = Gameobj_Manager.Canvas.transform.Find("Desktop1/WindowArea/").GetComponentsInChildren(typeof(Visage), true);
        foreach (Visage vs in temp)
            vs.SearchVisage("Joy Aun");
    }

    public void Rena_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(2);
        Component[] temp = Gameobj_Manager.Canvas.transform.Find("Desktop1/WindowArea/").GetComponentsInChildren(typeof(Visage), true);
        foreach (Visage vs in temp)
           vs.SearchVisage("Rena Woo");
    }

    public void Bouquet_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(3);
    }

    public void JamesKwan_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(2);
        Component[] temp = Gameobj_Manager.Canvas.transform.Find("Desktop1/WindowArea/").GetComponentsInChildren(typeof(Visage), true);
        foreach (Visage vs in temp)
            vs.SearchVisage("James Kwan");
    }

    public void AlexPerry_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(2);
        Component[] temp = Gameobj_Manager.Canvas.transform.Find("Desktop1/WindowArea/").GetComponentsInChildren(typeof(Visage), true);
        foreach (Visage vs in temp)
            vs.SearchVisage("Alex Perry");
    }

    public void LangxianCity_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(4);
    }

    public void Looklook_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(4);
    }

    public void LTBMC_Onclick()
    {
        GameObject.Find("Desktop1/TaskBar/Apps/BrovoShortcut").gameObject.GetComponent<Brovo>().SniffindOpen(5);
    }
}
