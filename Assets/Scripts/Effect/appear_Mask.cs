using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 10/20/2019 by Zijie Zhang
//---<Purpose>---
//The purpose of this script is to create a fade in/out effect so that players know where to click apparently.
//---</Purpose>---

//---<LOGS>---
//10/20/2019
//For keep fading in and out effect

//10/28/2019
//Added if click then stop the effect.
//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class appear_Mask : MonoBehaviour
{
    Color original_Color; //The original Color
    Color destinate_Color;//color try to fade in
    public Image current_Image; //image that uses effect

    private void Awake()
    {
        Color temp = this.GetComponent<Image>().color;
        temp.a = 1.0f;
        this.GetComponent<Image>().color = temp;
        StartCoroutine(FadeTo(1.0f, .5f)); //start it on awake
    }

    private void OnEnable()
    {
        Color temp = this.GetComponent<Image>().color;
        temp.a = 1.0f;
        this.GetComponent<Image>().color = temp;
        StartCoroutine(FadeTo(1.0f, .5f));
    }


    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = current_Image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            current_Image.color = newColor;
            yield return null;
        }
        StartCoroutine(FadeOut(0.0f, .5f)); //fade to 0.0f

    }

    IEnumerator FadeOut(float aValue, float aTime)
    {
        float alpha = current_Image.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            current_Image.color = newColor;
            yield return null;
        }
        StartCoroutine(FadeTo(1.0f, .5f)); //fade back to 1.0f
    }

    public void On_Click()
    {
        StopAllCoroutines();
        Color temp = current_Image.color;
        temp.a = 1.0f;
        current_Image.color = temp;
        Destroy(this.GetComponent<appear_Mask>()); //if the image  is clicked, stop the effect
    }








}
