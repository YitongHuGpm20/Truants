using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool syncDocs = false;
    public static bool impFile = false;
    public static bool bouquetButton = false;

    //keycode
    public static bool keycode = false;
    public static bool keycodemail = false;

    //third mail popup
    public static bool firstmail = false;
    public static bool secondmail = false;

    //fourth mail popup
    public static bool fourthmail = false;

    //gameOverAnimation start
    public static bool gameOverAnimation = false;
    public static bool gameWonAnimation = false;
    public static bool earlyAccessEnding = false;

    //dynamic map
    public static bool dynamicMap = false;

    //sd2 start
    public static bool sd2 = false;

    //sd3 start
    public static bool sd3 = false;

    //sd4 start
    public static bool sd4 = false;

    //sd5
    public static bool sd5 = false;

    //sd6 start
    public static bool sd6 = false;

    //scrollbar thing
    public static bool sdScroll1 = false;
    public static bool sdScroll2 = false;
    public static bool sdScroll3 = false;
    public static bool sdScroll4 = false;
    public static bool sdScroll5 = false;
    public static bool sdScroll6 = false;

    //syncdocs conversations end
    public static bool[] sdend = new bool[6];

    // Settings
    public static bool typingEffectOn = true;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sdend.Length; i++) sdend[i] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
