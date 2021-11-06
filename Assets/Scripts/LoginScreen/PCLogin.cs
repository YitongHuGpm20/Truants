using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCLogin : MonoBehaviour
{
    [SerializeField]
    private InputField Password;

    public GameObject notFilled;
    public GameObject incorrect;
    public GameObject login;
    public GameObject loginpanel;
    public GameObject startscreen;
    public GameObject Loading;
    public GameObject hint;
    public GameObject welcomeText;
    float time;
    float loadingTime;
    float hintTime;
    bool notfilledTime;
    bool incorrectTime;
    bool loginoff;
    bool hintOn;
    bool allowEnter;
    int voCount = 0;
    bool once = true;
    public void Start()
    {
        notfilledTime = false;
        incorrectTime = false;
        loginoff = false;
        allowEnter = true;
    }

    public void LoginInfo()
    {
        string password = Password.text;

        if(password == "")
        {
            SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[1]);
            notFilled.SetActive(true);
            notfilledTime = true;
        }
        else if (password == "abcd1234")
        {
            SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[0]);
            login.SetActive(false);
            loginoff = true;
            Loading.SetActive(true);
            welcomeText.GetComponent<Text>().text = "Enjoy your work, Scott Bowers :P";
        }
        else
        {
            voCount++;
            SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[1]);
            if(voCount < 2 && once)
                SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[9]);

            incorrect.SetActive(true);
            incorrectTime = true;
        }
    }

    public void Update()
    {
        if (incorrectTime)
            time += Time.deltaTime;

        if (notfilledTime)
            time += Time.deltaTime;

        if (loginoff)
            loadingTime += Time.deltaTime;

        if (hintOn)
            hintTime += Time.deltaTime;

        if (time > 3.0f)
        {
            incorrect.SetActive(false);
            notFilled.SetActive(false);
            notfilledTime = false;
            incorrectTime = false;
            time = 0;
        }

        if (hintTime > 3.0f)
        {
            hint.SetActive(false);
            hintTime = 0;
        }

        if(loadingTime > 2.0f)
        {
            loginpanel.SetActive(false);
            startscreen.SetActive(true);
        }

        if(!Password.isFocused && Password.text != "" && Input.GetKeyDown(KeyCode.Return))
            LoginInfo();  
    }

    public void ShowHint()
    {
        SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[2]);
        hint.SetActive(true);
        foreach(Transform temp in hint.transform)
        {
            temp.gameObject.SetActive(true);
        }
        once = false;
        hintOn = true;
        if (voCount == 1)
        {
            
            SettingsManager.instance.PlaySFX2D(SettingsManager.instance.sfxClips[10]);
            voCount++;
        }

    }

    public void QuitGame()
    {
        //Go back to main menu
    }
}
