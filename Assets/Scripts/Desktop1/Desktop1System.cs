using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Desktop1System : MonoBehaviour
{
    public GameObject SystemMenu;
    public GameObject MenuBar;
    public GameObject[] sysButtons;
    public GameObject[] sysWindows;
    bool systemMenuOn;

    public GameObject[] aboutTabs;
    public GameObject[] aboutPages;
    Color curAboTabColor;
    Color othAboTabColor;
    Color curAboTxtColor;
    Color othAboTxtColor;

    // Start is called before the first frame update
    void Start()
    {
        
        systemMenuOn = false;
        curAboTabColor = new Color32(60, 60, 60, 255);
        othAboTabColor = new Color32(255, 255, 255, 255);
        curAboTxtColor = new Color32(255, 255, 255, 255);
        othAboTxtColor = new Color32(50, 50, 50, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            HomeButton();
    }

    int findIndex(GameObject obj, GameObject[] list)
    {
        int index = -1;
        for (int i = 0; i < list.Length; ++i)
        {
            if (list[i] == obj)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public void HomeButton()
    {
        if (systemMenuOn)
        {
            SystemMenu.SetActive(false);
            systemMenuOn = false;
            MenuBar.transform.SetAsFirstSibling();
        }
        else
        {
            SystemMenu.SetActive(true);
            MenuBar.transform.SetAsLastSibling();
            systemMenuOn = true;
        }
    }

    public void OpenWindow()
    {
        GameObject thisButton = EventSystem.current.currentSelectedGameObject;
        int index = findIndex(thisButton, sysButtons);
        sysWindows[index].SetActive(true);
        sysWindows[index].transform.SetAsLastSibling();
        sysWindows[index].transform.parent.transform.SetAsLastSibling();
        SystemMenu.SetActive(false);
        systemMenuOn = false;
    }

    public void CloseWindow()
    {
        GameObject thisButton = EventSystem.current.currentSelectedGameObject;
        GameObject topbar = thisButton.transform.parent.gameObject;
        GameObject thisWindow = topbar.transform.parent.gameObject;
        thisWindow.SetActive(false);
    }

    public void OpenAboutTab()
    {
        GameObject thisTab = EventSystem.current.currentSelectedGameObject;
        int index = findIndex(thisTab, aboutTabs);
        for(int i = 0; i < aboutTabs.Length; ++i)
        {
            if(aboutTabs[i] == thisTab)
            {
                aboutPages[i].SetActive(true);
                aboutTabs[i].GetComponent<Image>().color = curAboTabColor;
                aboutTabs[i].transform.GetChild(0).GetComponent<Text>().color = curAboTxtColor;
            }
            else
            {
                aboutPages[i].SetActive(false);
                aboutTabs[i].GetComponent<Image>().color = othAboTabColor;
                aboutTabs[i].transform.GetChild(0).GetComponent<Text>().color = othAboTxtColor;
            }
        }
    }
}
