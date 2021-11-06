using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taskbar : MonoBehaviour
{
    Text date;
    Text time;
    // Start is called before the first frame update
    void Start()
    {
        date = GameObject.Find("Date").GetComponent<Text>();
        time = GameObject.Find("Time").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        date.text = System.DateTime.Today.ToString("MM-dd-yyyy") + " | " + Application.systemLanguage + ", " + "FUS";
        System.DateTime time1 = System.DateTime.Now;
        string hour = LeadingZero(time1.Hour);
        string minute = LeadingZero(time1.Minute);
        string second = LeadingZero(time1.Second);
        time.text = hour + ":" + minute + ":" + second;
    }
        string LeadingZero(int n)
        {
            return n.ToString().PadLeft(2, '0');
        }
}
