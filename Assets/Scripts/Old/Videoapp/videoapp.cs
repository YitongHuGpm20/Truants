using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoapp : MonoBehaviour
{
    public GameObject videoline;
    public GameObject videoWindow;
    public bool min;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickBrowser()
    {
        if (min)
        {
            videoline.SetActive(true);
            videoWindow.SetActive(true);
            min = false;

        }
    }

    public void closeBrowser()
    {
        videoline.SetActive(false);
        videoWindow.SetActive(false);
    }

    public void minBrowser()
    {
        videoline.SetActive(true);
        videoWindow.SetActive(false);
        min = true;
    }
}
