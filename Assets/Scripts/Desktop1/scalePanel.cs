using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scalePanel : MonoBehaviour
{

    public Slider windowSlider;


    public void Update()
    {
        transform.localScale = new Vector3(windowSlider.value, windowSlider.value, windowSlider.value);
    }
  
    
}
