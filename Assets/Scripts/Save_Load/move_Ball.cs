using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Created in 09/26/2019 by Zijie Zhang
//---<LOGS>---

//09/26/2019
//Created a move ball script to test save and load function

//---</LOGS>---

//---<Bugs or Questions in Mind>--
//---</Bugs or Questions in Mind>---
public class move_Ball : MonoBehaviour
{
    private float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        } //A and D to move
    }
}
