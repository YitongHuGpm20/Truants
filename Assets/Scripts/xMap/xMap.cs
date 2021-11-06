using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xMap : MonoBehaviour
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

    public void TogglexMap()
    {
        if (window.activeSelf)
        {
            ClosexMap();
        }
        else
        {
            window.SetActive(true);
            underline.SetActive(true);
            slider.SetActive(true);
            EarlyAccessEnding();
        }
    }

    public void ClosexMap()
    {
        window.SetActive(false);
        underline.SetActive(false);
        slider.SetActive(false);
    }

    void EarlyAccessEnding()
    {
        GameManager.earlyAccessEnding = true;
    } //The Early Acess ends here
}
