using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VisageProfile : MonoBehaviour
{
    public GameObject visageSearch;
    public GameObject visageProfiles;
    public GameObject content;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseProfile()
    {
        GameObject thisbutton = EventSystem.current.currentSelectedGameObject;
        thisbutton.transform.parent.gameObject.SetActive(false);
        visageProfiles.SetActive(false);
        visageSearch.SetActive(true);
        content.gameObject.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2060);
    }
}
