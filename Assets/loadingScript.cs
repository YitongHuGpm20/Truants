using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingScript : MonoBehaviour
{
    public Transform TextIndicator;
    public Transform loadingBar;
    public Transform loadingCircle;
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed;
    public GameObject loginScreen;
    public GameObject bootScreen;
    public RectTransform particleSystemHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
           // TextIndicator.GetComponent<Text>().text = "kudOS Loading: " + ((int)currentAmount).ToString() + " %";
        }
        else
        {
           // TextIndicator.GetComponent<Text>().text = "DONE!";
            loginScreen.SetActive(true);
            bootScreen.SetActive(false);
        }
       // loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
        loadingCircle.GetComponent<Image>().fillAmount = currentAmount / 100;
        particleSystemHolder.rotation = Quaternion.Euler(new Vector3(0f, 0f, -(currentAmount/100) * 360));
        
    }
}
