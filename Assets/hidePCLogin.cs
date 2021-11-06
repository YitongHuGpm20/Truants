using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidePCLogin : MonoBehaviour
{
    public GameObject pclogin;
    // Start is called before the first frame update
    private void Awake()
    {
        pclogin.GetComponent<PCLogin>().enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pclogin.GetComponent<PCLogin>().enabled = false;
    }
}
