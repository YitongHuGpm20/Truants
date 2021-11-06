using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField_Property : MonoBehaviour
{
    public string text;
    private Text text_Component;

    private void Awake()
    {
        text_Component = this.transform.Find("Placeholder").GetComponent<Text>();
    }

    public IEnumerator RevealText()
    {
        if(text_Component==null)
            text_Component = this.transform.Find("Placeholder").GetComponent<Text>();
        var originalString = text;
        text_Component.text = "";

        var numCharsRevealed = 0;
        while (numCharsRevealed < originalString.Length)
        {
            while (originalString[numCharsRevealed] == ' ')
                ++numCharsRevealed;

            ++numCharsRevealed;

            text_Component.text = originalString.Substring(0, numCharsRevealed);

            yield return new WaitForSeconds(0.12f);
            
        }
        Create_AccountPanelController.Running_Coroutine++;
        if(Create_AccountPanelController.Running_Coroutine<Create_AccountPanelController.obj_InputFields.Count)
            StartCoroutine(Create_AccountPanelController.obj_InputFields[Create_AccountPanelController.Running_Coroutine].GetComponent<InputField_Property>().RevealText());
    }
}
