using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileBrowserScript : MonoBehaviour
{
    public GameObject ImpFiles;
    public GameObject ImpFilesBrowser;
    bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.impFile)
        {
            ImpFiles.SetActive(true);
            GameManager.impFile = false;
        }
    }

    public void clickFile()
    {

        ImpFilesBrowser.SetActive(true);
        //if (start)
        //{
        //    GameManager.sd5 = true;
        //    //Debug.Log("sd5: " + GameManager.sd5);
        //    start = false;
        //}

    }
}
