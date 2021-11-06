using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.0f;
    public Text downloadText;
    public Text progressNumber;

    public static bool ifFinished;


    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update()
    {
        int a = 0;
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            a = (int)(imageComp.fillAmount * 100);
            if (a > 0 && a <= 33)
            {
                downloadText.text = "Please Wait...";
            }
            else if (a > 33 && a <= 99)
            {
                downloadText.text = "Downloading...";
            }
            else if (a <= 100)
            {
                downloadText.text = "Finished!";
                ifFinished = true;
            }
            else
            {
            }
            progressNumber.text = a + "%";

        }
        /*else
        {
            imageComp.fillAmount = 0.0f;
            progressNumber.text = "0%";
        }*/
    }
}
