using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midium : MonoBehaviour
{
    public GameObject window;
    public GameObject underline;
    public GameObject slider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleMidium()
    {
        if (window.activeSelf)
        {
            CloseMidium();
        }
        else
        {
            window.SetActive(true);
            window.transform.SetAsLastSibling();
            underline.SetActive(true);
            slider.SetActive(true);
        }
    }

    public void CloseMidium()
    {
        window.SetActive(false);
        underline.SetActive(false);
        slider.SetActive(false);
    }
}
