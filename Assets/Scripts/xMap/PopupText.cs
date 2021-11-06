using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>(); 
    }

    public void BeginPopup()
    {
        StartCoroutine(Popup());
    }

    private IEnumerator Popup()
    {
        yield return new WaitForSeconds(1.0f);
        this.gameObject.SetActive(false);
    }
}
