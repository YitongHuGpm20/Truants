using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Brovo : MonoBehaviour
{
    [Header("General")]
    public GameObject browserline;
    public GameObject browserWindow;
    public GameObject[] tabs;
    public GameObject[] websites;
    public GameObject[] bookmarks;
    public GameObject slider;
    public GameObject bookmarkList;
    public InputField URLAddress;
    public GameObject webAddress;
    Color currentTabColor;
    Color otherTabColor;
    bool validURL;
    string[] urls;
    bool urlEmptied;
    string curUrl;

    [Header("SyncDocs")]
    public GameObject[] sdTabs;
    public GameObject[] sdPages;
    public GameObject[] sdTMs;
    public GameObject[] sdChoices;
    public GameObject sdPanel;
    public GameObject sdScrollview;
    public GameObject sdPaper;
    bool sdNotificationOn;
    float sdNotificationTime;

    [Header("Looklook")]
    public GameObject[] preSearchs;
    public GameObject[] llPages;
    public Scrollbar llScrollbar;
    string[] lls; //extra text for Looklook url
    string currentll;

    [Header("Dynamic Map")]
    public GameObject dynamicMap;
    public GameObject dynamicMapShortcut;

    [Header("LTBMC Official Website")]
    public GameObject[] lowTabs;
    public GameObject[] lowPages;
    Color curLowColor;
    Color othLowColor;

    // Start is called before the first frame update
    void Start()
    {
        validURL = false;

        urls = new string[12];
        lls = new string[21];
        
        urls[0] = "http://www.sniffind.kangmu";
        urls[1] = "http://www.syncdocs1.kangmu";
        urls[2] = "http://www.visage.kangmu";
        urls[3] = "http://www.bouquet.kangmu";
        urls[4] = "http://www.looklook.kangmu";
        urls[5] = "http://www.ltbmc.kangmu";
        urls[6] = "http://www.trending.kangmu";
        urls[7] = "http://www.syncdocs2.kangmu";
        urls[8] = "http://www.syncdocs3.kangmu";
        urls[9] = "http://www.syncdocs4.kangmu";
        urls[10] = "http://www.syncdocs5.kangmu";
        urls[11] = "http://www.syncdocs6.kangmu";

        lls[0] = "/ltbmc";
        lls[1] = "/langxian_city";
        lls[2] = "/nacheon_state";
        lls[3] = "/federation_of_shincho";
        lls[4] = "/scrum_university";
        lls[5] = "/new_ganttaki";
        lls[6] = "/perphorson_province";
        lls[7] = "/republic_of_prifabia";
        lls[8] = "/scrumos";
        lls[9] = "/brovo";
        lls[10] = "/yeemeow";
        lls[11] = "/tudu";
        lls[12] = "/goodpoint";
        lls[13] = "/sniffind";
        lls[14] = "/syncdocs";
        lls[15] = "/visage";
        lls[16] = "/visager";
        lls[17] = "/bouquet";
        lls[18] = "/looklook";
        lls[19] = "/trending";
        lls[20] = "/true_ant_games";

        currentll = lls[0];
        curUrl = webAddress.GetComponent<Text>().text;

        currentTabColor = new Color32(128, 197, 217, 255);
        otherTabColor = new Color32(195, 213, 218, 255);
        curLowColor = new Color32(38, 143, 140, 255);
        othLowColor = new Color32(27, 162, 159, 255);

        sdNotificationOn = false;
        sdNotificationTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.dynamicMap)
        {
            dynamicMap.SetActive(true);
            dynamicMapShortcut.SetActive(true);
        }
        if (!URLAddress.isFocused && URLAddress.text != "" && Input.GetKey(KeyCode.Return))  //press enter to search url
            SearchURL();
        if (URLAddress.isFocused)
            webAddress.GetComponent<Text>().text = "";

        if (GameManager.sdScroll2)
        {
            
            sdScrollview.GetComponent<ScrollRect>().content = sdPages[1].GetComponent<RectTransform>();
            GameManager.sdScroll2 = false;
        }

        if (GameManager.sdScroll3)
        {
            sdScrollview.GetComponent<ScrollRect>().content = sdPages[2].GetComponent<RectTransform>();
            GameManager.sdScroll3 = false;
        }

        if (GameManager.sdScroll4)
        {
            sdScrollview.GetComponent<ScrollRect>().content = sdPages[3].GetComponent<RectTransform>();
            GameManager.sdScroll4 = false;
        }

        if (GameManager.sdScroll5)
        {
            sdScrollview.GetComponent<ScrollRect>().content = sdPages[4].GetComponent<RectTransform>();
            GameManager.sdScroll5 = false;
        }

        if (GameManager.sdScroll6)
        {
            sdScrollview.GetComponent<ScrollRect>().content = sdPages[5].GetComponent<RectTransform>();
            GameManager.sdScroll6 = false;
        }

        if (sdNotificationOn)
            SyncDocsNotificationFlashing();
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

    //Brovo window, tabs, bookmarks =========================================================================================

    public void ToggleBrowser()
    {
        if (!browserWindow.activeSelf)
        {
            browserline.SetActive(true);
            browserWindow.SetActive(true);
            slider.SetActive(true);
            browserWindow.transform.SetAsLastSibling();
        }
        else
            CloseBrowser();
    } //Open or close Brovo window

    public void CloseBrowser()
    {
        browserline.SetActive(false);
        browserWindow.SetActive(false);
        slider.SetActive(false);
    } //Close Brovo window

    public void OpenTabWebsite(int index)
    {
        tabs[index].SetActive(true);
        tabs[index].GetComponent<Image>().color = currentTabColor;
        for (int j = 0; j < tabs.Length; ++j)
        {
            if (j != index)
            {
                tabs[j].GetComponent<Image>().color = otherTabColor;
                websites[j].SetActive(false);
            }
        }
        websites[index].SetActive(true);
        if(index == 4)
            webAddress.GetComponent<Text>().text = urls[4] + currentll;
        else
            webAddress.GetComponent<Text>().text = urls[index];
        curUrl = webAddress.GetComponent<Text>().text;
    } //Open a website with its index

    public void SwitchTab()
    {
        GameObject thisTab = EventSystem.current.currentSelectedGameObject;
        int index = findIndex(thisTab, tabs);
        OpenTabWebsite(index);
    } //Switch to another website that already opened by clicking on the tab

    void SwitchTabBetween(int fromtab, int totab)
    {
        tabs[fromtab].GetComponent<Image>().color = otherTabColor;
        websites[fromtab].SetActive(false);
        tabs[totab].GetComponent<Image>().color = currentTabColor;
        websites[totab].SetActive(true);
        if (totab == 4)
            webAddress.GetComponent<Text>().text = urls[4] + currentll;
        else
            webAddress.GetComponent<Text>().text = urls[totab];
    } //Hide current website (fromtab), show another opened website (totab)

    public void CloseTab()
    {
        GameObject thisbutton = EventSystem.current.currentSelectedGameObject;
        GameObject thistab = thisbutton.gameObject.transform.parent.gameObject;
        thistab.SetActive(false);

        int index = findIndex(thistab, tabs);

        if (websites[index].activeSelf) //if you are closing the current website
        {
            websites[index].SetActive(false);
            bool hasNextPage = false;
            bool hasFrontPage = false;
            for (int i = index + 1; i < tabs.Length; i++)
            {
                if (tabs[i].activeSelf)  //if there is a tab next to the current tab, make that tab the current tab
                {
                    tabs[i].GetComponent<Image>().color = currentTabColor;
                    websites[i].SetActive(true);
                    if (i == 4)
                        webAddress.GetComponent<Text>().text = urls[4] + currentll;
                    else
                        webAddress.GetComponent<Text>().text = urls[i];
                    hasNextPage = true;
                    break;
                }
            }
            if (!hasNextPage) //if no next tab, make tab on the left the current tab
            {
                for (int i = index - 1; i >= 0; i--)
                {
                    if (tabs[i].activeSelf)
                    {
                        tabs[i].GetComponent<Image>().color = currentTabColor;
                        websites[i].SetActive(true);
                        if (i == 4)
                            webAddress.GetComponent<Text>().text = urls[4] + currentll;
                        else
                            webAddress.GetComponent<Text>().text = urls[i];
                        hasFrontPage = true;
                        break;
                    }
                }
            }
            if (!hasFrontPage && !hasNextPage)  //if you are closing the only one left
            {
                webAddress.GetComponent<Text>().text = "Input URL to start...";
                webAddress.GetComponent<Text>().color = new Color32(0, 0, 0, 150);
            }
        }
    } //Close a website by clicking close button, show another webpage

    public void ToggleBookmarkList()
    {
        if (bookmarkList.activeSelf)
            bookmarkList.SetActive(false);
        else
            bookmarkList.SetActive(true);
    } //Open/close Bookmark list

    public void OpenBookmark()
    {
        GameObject bookmark = EventSystem.current.currentSelectedGameObject;
        int index = findIndex(bookmark, bookmarks);
        if (!tabs[index].activeSelf)
            OpenTabWebsite(index);
        bookmarkList.SetActive(false);
    } //Open a website from its bookmark

    public void SearchURL()
    {
        validURL = false;
        string url = URLAddress.text;
        for (int i = 0; i < 6; i++)
        {
            if (url == urls[i])
            {
                OpenTabWebsite(i);
                curUrl = url;
                validURL = true;
                break;
            }
        }
        if (!validURL)
        {
            Debug.Log("wrong url");
        }
        URLAddress.Select();
        URLAddress.text = "";
        webAddress.GetComponent<Text>().text = curUrl;
    }//Open a webpage by typing its url

    //Sniffind==========================================================================================================

    public void SniffindOpen(int optional = 0)
    {
        if (optional != 0)
        {
            int index = optional;
            if (!tabs[index].activeSelf) //if open first time
                OpenTabWebsite(index);
            else
                SwitchTabBetween(0, index);
            if (!bookmarks[index].activeSelf)  //if open first time
                bookmarks[index].SetActive(true);
        }
    }

    //Looklook=========================================================================================================

    void OpenLooklookPage(int index)
    {
        for (int j = 0; j < llPages.Length; ++j)
        {
            if (llPages[j].activeSelf)
            {
                llPages[j].SetActive(false);
                break;
            }
        }
        llPages[index].SetActive(true);
        webAddress.GetComponent<Text>().text = urls[4] + lls[index];
        currentll = lls[index];
        llScrollbar.value = 1;
    } //Open a LL page with its index

    public void SwitchLooklookPage()
    {
        GameObject thisPreSearch = EventSystem.current.currentSelectedGameObject;
        int index = findIndex(thisPreSearch, preSearchs);
        OpenLooklookPage(index);
    } //Open a LL page by clicking previous search button

    public void Langxianll_To_LTBMCll()  //a link from Looklook-LangxianCity to Looklook-LTBMC
    {
        llPages[1].SetActive(false);
        llPages[0].SetActive(true);
        webAddress.GetComponent<Text>().text = urls[4] + lls[0];
        currentll = lls[0];
        preSearchs[0].SetActive(true);
        llScrollbar.value = 1;
    }

    public void LTBMCll_To_LTBMCow()  //a link from Looklook-LTBMC to LTBMC official website
    {
        if (tabs[5].activeSelf)
            SwitchTabBetween(4, 5);
        else
            OpenTabWebsite(5);
        bookmarks[5].SetActive(true);
    }

    //LTBMC Official Website ==============================================================================================

    public void OpenLOWPage()
    {
        GameObject thisTab = EventSystem.current.currentSelectedGameObject;
        int index = findIndex(thisTab, lowTabs);
        for(int i = 0; i < lowTabs.Length; ++i)
        {
            if(i == index)
            {
                lowTabs[i].GetComponent<Image>().color = curLowColor;
                lowPages[i].SetActive(true);
            }
            else
            {
                lowTabs[i].GetComponent<Image>().color = othLowColor;
                lowPages[i].SetActive(false);
            }
        }
    } //Open web page by clicking the tab in menu bar

    //SyncDocs ===========================================================================================================

    public void ToggleSyncDocsFilesPanel()
    {
        if (sdPanel.activeSelf)
        {
            sdPanel.SetActive(false);
            sdScrollview.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1200);
            sdScrollview.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
            sdPaper.transform.parent.transform.parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1200);
            sdPaper.transform.parent.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
            for (int i = 0; i < sdChoices.Length; i++)
                sdChoices[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        }
        else
        {
            sdPanel.SetActive(true);
            sdScrollview.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1000);
            sdScrollview.GetComponent<RectTransform>().anchoredPosition = new Vector3(100, -50, 0);
            sdPaper.transform.parent.transform.parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1000);
            sdPaper.transform.parent.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(100, -50, 0);
            for (int i = 0; i < sdChoices.Length; i++)
                sdChoices[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(100, 0, 0);
        }
    } //Expand/minimize previous version panel

    public void OpenSyncDocsPage()
    {
        GameObject thisTab = EventSystem.current.currentSelectedGameObject;
        int index = findIndex(thisTab, sdTabs);
        sdScrollview.GetComponent<ScrollBarOverride>().content = sdPages[index].GetComponent<RectTransform>();
        for (int i = 0; i < sdTabs.Length; i++)
        {
            if(i == index)
                sdPages[i].SetActive(true);
            else
                sdPages[i].SetActive(false);
        }
        sdPaper.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, sdPages[index].GetComponent<RectTransform>().rect.height);
    } //Open a version of this document by clicking its tab in the panel

    public void SyncDocsNotification(bool turnOn)
    {
        if (turnOn)
        {
            sdNotificationTime = 0;
            sdNotificationOn = true;
        }
        else
        {
            tabs[1].transform.GetChild(1).GetComponent<Text>().text = "GDD 200...";
            sdNotificationOn = false;
        }
    }

    void SyncDocsNotificationFlashing()
    {
        sdNotificationTime += Time.deltaTime;
        if (sdNotificationTime <= 1)
            tabs[1].transform.GetChild(1).GetComponent<Text>().text = "(1)GDD 2...";
        else if (sdNotificationTime <= 2)
            tabs[1].transform.GetChild(1).GetComponent<Text>().text = "New Upd...";
        else
            sdNotificationTime = 0;
    }
}