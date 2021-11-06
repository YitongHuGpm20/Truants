using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileBrowser : MonoBehaviour
{
    public GameObject underline;
    public GameObject window;
    public GameObject slider;

    private bool isWindowOn;

    // Start is called before the first frame update
    void Start()
    {
        isWindowOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
