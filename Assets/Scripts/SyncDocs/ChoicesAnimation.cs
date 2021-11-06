using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script handles all the animation effects and non-conversation-relate UI functions of SyncDocs Choice panels
/// </summary>

public class ChoicesAnimation : MonoBehaviour
{
    GameObject option1;
    GameObject option2;
    GameObject option3;
    GameObject closeButton;
    GameObject openButton;
    Text closeText;
    Text openText;
    Text txt;
    Color lightblue;
    Color darkblue;
    Color goalColor;
    float t;
    float duration;

    // Start is called before the first frame update
    void Start()
    {
        option1 = this.transform.GetChild(0).gameObject;
        option2 = this.transform.GetChild(1).gameObject;
        option3 = this.transform.GetChild(2).gameObject;
        closeButton = this.transform.GetChild(3).gameObject;
        openButton = this.transform.GetChild(4).gameObject;
        closeText = closeButton.transform.GetChild(0).gameObject.GetComponent<Text>();
        openText = openButton.transform.GetChild(0).gameObject.GetComponent<Text>();
        lightblue = new Color32(221, 236, 244, 50);
        darkblue = new Color32(80, 199, 229, 100);
        goalColor = darkblue;
        t = 0;
        duration = 1;
        txt = closeText;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleButtonTextAnimation();
    }

    void ToggleButtonTextAnimation()
    {
        if (t < 1)
            t += Time.deltaTime / duration;
        txt.color = Color32.Lerp(txt.color, goalColor, t);
        if (txt.color == lightblue)
        {
            goalColor = darkblue;
            t = 0;
        }
        if (txt.color == darkblue)
        {
            goalColor = lightblue;
            t = 0;
        }
    } // the animation of the text box of open/close buttons

    public void ToggleOptions()
    {
        if (option1.activeSelf)
        {
            option1.SetActive(false);
            option2.SetActive(false);
            option3.SetActive(false);
            closeButton.SetActive(false);
            openButton.SetActive(true);
            txt = openText;
        }
        else
        {
            option1.SetActive(true);
            option2.SetActive(true);
            option3.SetActive(true);
            closeButton.SetActive(true);
            openButton.SetActive(false);
            txt = closeText;
        }
        t = 0;
        goalColor = darkblue;
        txt.color = lightblue;
    } // hide the options in case the players need to read the previous conversation contents
}
