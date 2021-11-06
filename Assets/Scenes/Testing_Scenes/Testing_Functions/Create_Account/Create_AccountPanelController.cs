using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Create_AccountPanelController : MonoBehaviour
{
    GameObject Inputfields;
    GameObject Create_Button;
    public static List<GameObject> obj_InputFields = new List<GameObject>();
    public static int Running_Coroutine = 0;
    private PlayableDirector _Director;
    public bool isInitialized = false;
    private void Awake()
    {

        Inputfields = this.transform.parent.transform.Find("InputFields").gameObject;
        foreach (Transform obj in Inputfields.transform)
        {
            obj_InputFields.Add(obj.gameObject);
        }
        StartCoroutine(obj_InputFields[Running_Coroutine].GetComponent<InputField_Property>().RevealText());
        Create_Button = this.transform.parent.transform.Find("Create_Button").gameObject;
    }

    public void on_CreateProfile()
    {
        if (isInitialized == false)
        {
            Debug.Log("hi");
            GameObject obj = this.transform.parent.transform.Find("Create_Button").gameObject;
            obj.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
           obj.GetComponent<Button>().onClick.AddListener(on_CreateProfile);
        }
        _Director = this.transform.parent.transform.Find("Timeline").GetComponent<PlayableDirector>();
        if (isInitialized &&_Director.state == PlayState.Paused)
            Destroy(this.transform.parent.gameObject);
        isInitialized = true;

    }

    




}
