using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visage : MonoBehaviour
{
    public InputField visageSearch;
    public GameObject visageProfiles;
    public GameObject[] profiles;
    public GameObject content;
    bool allowEnter;
    string[] profileNames;
    public GameObject visageCreateProfile;
    private float ifOnce = 0;
    // Start is called before the first frame update
    void Awake()
    {
        profileNames = new string[5];
        profileNames[0] = ""; //for no result
        profileNames[1] = "joy aun";
        profileNames[2] = "rena woo";
        profileNames[3] = "james kwan";
        profileNames[4] = "alex perry";
        visageCreateProfile = GameObject.FindGameObjectWithTag("visageCreate");
    }

    // Update is called once per frame
    void Update()
    {
        if (visageCreateProfile.activeInHierarchy)
        {
            ifOnce++;
            if (ifOnce == 2)
            {
                SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[14]);
                
            }
            

        }
        if (visageSearch.text != "" && Input.GetKey(KeyCode.Return) && allowEnter)
        {
            SearchVisage();
            allowEnter = false;
        }
        else
        {
            allowEnter = visageSearch.isFocused;
        }
    }

    public void SearchVisage()
    {
        visageProfiles.SetActive(true);
        visageSearch.gameObject.SetActive(false);
        string name = visageSearch.text.ToLower();
        bool hasResult = false;
        for(int i = 0; i < profileNames.Length; ++i)
        {
            if(name == profileNames[i])
            {
                profiles[i].SetActive(true);
                hasResult = true;
                ChangeScrollviewHeight(i);
            }
            else
            {
                profiles[i].SetActive(false);
            }
        }
        if (!hasResult)
            profiles[0].SetActive(true);
    }

    public void SearchVisage(string optional = "")
    {
        visageProfiles.SetActive(true);
        visageSearch.gameObject.SetActive(false);
        string name = optional.ToLower();
        bool hasResult = false;
        for (int i = 0; i < profileNames.Length; ++i)
        {
            if (name == profileNames[i])
            {
                profiles[i].SetActive(true);
                hasResult = true;
                ChangeScrollviewHeight(i);
            }
            else
            {
                profiles[i].SetActive(false);
            }
        }
        if (!hasResult)
            profiles[0].SetActive(true);
    }

    private void ChangeScrollviewHeight(int index) //dynamic change the height of scroll view base on each profile's height (index 1-4)
    {
        float topbar = profiles[index].transform.Find("TopBar").gameObject.transform.GetComponent<RectTransform>().rect.height;
        float banner = profiles[index].transform.Find("Banner").gameObject.transform.GetComponent<RectTransform>().rect.height;
        float timelineBackground = profiles[index].transform.Find("TimelineBackground").gameObject.transform.GetComponent<RectTransform>().rect.height;
        float scrollviewHeight = topbar + banner + timelineBackground;
        content.gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, scrollviewHeight);
    }
}
