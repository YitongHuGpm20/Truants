using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class files : MonoBehaviour
{
    public GameObject file;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openFile()
    {
        file.SetActive(true);
        file.transform.SetAsLastSibling();
    }

    public void closeFile()
    {
        file.SetActive(false);
    }
}
