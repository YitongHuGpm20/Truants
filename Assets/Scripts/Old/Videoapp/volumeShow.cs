using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeShow : MonoBehaviour
{
    public GameObject volumeSlider;
    bool volumeSlide;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlide = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void volumeClick()
    {
        volumeSlide = !volumeSlide;
        volumeSlider.SetActive(volumeSlide);
    }
}
