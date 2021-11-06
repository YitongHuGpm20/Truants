using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class YeeMeowManager : MonoBehaviour
{

    public GameObject[] emails;
    public GameObject[] emailContents;
    public GameObject newEmailDot;
    public GameObject newEmailNum;

    float thirdMailTime;
    float time;
    bool[] unread;
    int nenInt;

    // Start is called before the first frame update
    void Start()
    {
        thirdMailTime = 10.0f;
        nenInt = 2;
        newEmailNum.GetComponent<Text>().text = nenInt.ToString();
        unread = new bool[emails.Length];
        for (int i = 0; i < 4; ++i)
        {
            unread[i] = true;
            UnreadEmailUI(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!unread[0] && !unread[1] && !emails[2].activeSelf)
            time += Time.deltaTime;

        if (time > thirdMailTime)
        {
            time = 0;
            emails[2].SetActive(true);
            SettingsManager.instance.playSFXByID(4);
            nenInt++;
            newEmailNum.GetComponent<Text>().text = nenInt.ToString();
        }

        if (nenInt == 0)
            newEmailDot.SetActive(false);
        else
            newEmailDot.SetActive(true);

        if (GameManager.fourthmail)
        {
            emails[3].SetActive(true);
            SettingsManager.instance.playSFXByID(4);
            nenInt++;
            newEmailNum.GetComponent<Text>().text = nenInt.ToString();
            GameManager.fourthmail = false;
        }
    }

    int findEmailIndex(GameObject email)
    {
        int index = -1;
        for (int i = 0; i < emails.Length; ++i)
        {
            if (emails[i] == email)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public void OpenEmail()
    {
        GameObject thisEmail = EventSystem.current.currentSelectedGameObject;
        int index = findEmailIndex(thisEmail);
        for (int i = 0; i < emails.Length; ++i)
            emailContents[i].SetActive(false);
        emailContents[index].SetActive(true);
        if (unread[index])
        {
            unread[index] = false;
            nenInt--;
            newEmailNum.GetComponent<Text>().text = nenInt.ToString();
            ReadEmailUI(index);
        }
    }

    private void AddEmail(int index)
    {
        for (int i = 0; i < emails.Length; ++i)
            emailContents[i].SetActive(false);
        emailContents[index].SetActive(true);
    }

    private void UnreadEmailUI(int index)
    {
        emails[index].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        emails[index].transform.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Bold;
        emails[index].transform.GetChild(1).GetComponent<Text>().fontStyle = FontStyle.Bold;
        emails[index].transform.GetChild(0).GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        emails[index].transform.GetChild(1).GetComponent<Text>().color = new Color32(60, 60, 60, 255);
    }

    private void ReadEmailUI(int index)
    {
        emails[index].GetComponent<Image>().color = new Color32(225, 225, 225, 255);
        emails[index].transform.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Normal;
        emails[index].transform.GetChild(1).GetComponent<Text>().fontStyle = FontStyle.Normal;
        emails[index].transform.GetChild(0).GetComponent<Text>().color = new Color32(60, 60, 60, 255);
        emails[index].transform.GetChild(1).GetComponent<Text>().color = new Color32(100, 100, 100, 255);
    }
}
