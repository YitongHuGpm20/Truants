using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xPloit : MonoBehaviour
{
    public GameObject underline;
    public GameObject window;
    public GameObject slider;
    public LastSiblingCheck lastSibling;
    public Transform xploit;
    public GameObject consoleview;
    private bool isWindowOn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!lastSibling.IsLastSibling(xploit))
        {
            consoleview.GetComponent<ConsoleView>().inputField.enabled = false;
        }

        if (lastSibling.IsLastSibling(xploit))
        {
            consoleview.GetComponent<ConsoleView>().inputField.enabled = true;
        }

    }

    public void ToggleWindow()
    {
        if (!isWindowOn)
        {
            underline.SetActive(true);
            window.SetActive(true);
            window.transform.SetAsLastSibling();
            slider.SetActive(true);
            isWindowOn = true;
        }
        else
        {
            CloseWindow();
        }
    }

    public void CloseWindow()
    {
        underline.SetActive(false);
        window.SetActive(false);
        slider.SetActive(false);
        isWindowOn = false;
    }
}
