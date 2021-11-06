using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class task_Property : MonoBehaviour
{
    public bool is_Finished = false;
    public GameObject reference_Obj;
    [TextArea(4, 4)]
    public string task_Description;
    public int task_ID;
    public int finished_Counter;
    public int mission_Counter;

    public bool awake_Add;


    private void Awake()
    {

    }

    private void Start()
    {
        if (awake_Add)
        {
            // Debug.Log(this);

            task_Manager.add_Task(this); ;
            //Destroy(this);
        }
    }

    public void check_Status()
    {
        if (this.is_Finished)
            this.transform.Find("red_Check").localScale = new Vector3(1, 1, 1);
        else
            this.transform.Find("red_Check").localScale = new Vector3(0, 0, 0);

    }
    public void try_Finishtask_Task()
    {
        task_Manager.task_List.Find(n => n.task_ID == this.task_ID).finished_Counter++;
        if (task_Manager.task_List.Find(n => n.task_ID == this.task_ID).finished_Counter >= task_Manager.task_List.Find(n => n.task_ID == this.task_ID).mission_Counter)
        {
            this.is_Finished = true;
            this.transform.Find("red_Check").localScale = new Vector3(1, 1, 1);
            task_Manager.task_List.Find(n => n.task_ID == this.task_ID).is_Finished = true;
        }

    }

    //public override bool Equals(object other)
    //{
    //    //if (other == null)
    //    //    return false;
    //    //task_Property temp = other as task_Property;
    //    //if (temp == null)
    //    //    return false;
    //    //return this.task_ID = temp.task_ID &&
    //    //    this.is_Finished = temp.is_Finished
    //}

    public void add_Task()
    {
        task_Manager.add_Task(this);
       // Destroy(this);
    }
}
