using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 10/26/2019 by Zijie Zhang
//---<LOGS>---

//10/26/2019
//Created planner script for to do list

//01/15/2019
//This script is half finished, need to revise later for initializing new tasks and design

//---</LOGS>---

//---<Bugs or Questions in Mind>---
//1.Usage
//2.Animations
//---</Bugs or Questions in Mind>---
public class planner_Manager : MonoBehaviour
{
    public static List<task> task_List = new List<task>(); //initialize new task list
    public GameObject task_Prefab; //prefab for single task
    private bool opened = false;

    public class task //single task class
    {
        public string mission_Description; //description of the task
        public bool completed; //is this task compeletes
        public GameObject reference_Gameobject; //the gameobject
        public int ID; //task ID if needed
        //Animation transition;

        void set_completed()
        {
            this.completed = true; //compelete the task                                                            
        }

        public void destroy_Task()
        {
            GameObject.Destroy(reference_Gameobject); //destroy the task
        }

        public task(GameObject reference, string input_Description = "", bool input_Completed = false)
        {
            reference_Gameobject = reference;
            this.mission_Description = input_Description;
            this.completed = input_Completed;
            GameObject.FindObjectOfType<Text>().text = this.mission_Description;
            if (task_List.Count == 0)
                ID = 1;
            else
                ID = task_List.Count;
            
            //task constructor, and assign everything
        }

        public void finish_ByID(int input_ID)
        {
            if (task_List.Count <= 0)
                return;
            foreach(task item in task_List)
            {
                if(item.ID == input_ID)
                {
                    task temp = item;
                    task_List.Remove(item);
                    temp.destroy_Task();
                }
            }
            
        }//finish a specific task by ID

        private void activate_Animation()
        {
            //activate some transition animation, empty right now
        }

        public void finish_Last()
        {
            if (task_List.Count <= 0)
                return;
            task temp = task_List[task_List.Count - 1];
            task_List.RemoveAt(task_List.Count - 1);
            temp.destroy_Task();
        } //finish last task in the list
    }

    public void initialize_Newtask(string description)
    {
        if (task_List.Count >= 4) { Debug.Log("Too many tasks"); return; }
        foreach (task temp in task_List)
        {
            if (temp.mission_Description == description)
            {
                return;
            }

        }
        GameObject new_Task_Prefab = Instantiate(task_Prefab, this.transform);
        task new_Task = new task(new_Task_Prefab,description);
        task_List.Add(new_Task);
    } //create new task based on the giving description

    private void Start()
    {
        initialize_Newtask("Begin the day by reading your emails"); //initializing the the email at the beginning
    }

    public static void Destroy_Task() //destroy the last task
    {
        task temp = task_List[task_List.Count - 1];
        task_List.RemoveAt(task_List.Count - 1);
        temp.destroy_Task();
        Debug.Log(task_List.Count);
    }

    public static void Destory_TaskByContent(string Content) //destroy by content of the task
    {
        foreach (task temp in task_List)
        {
            if (temp.mission_Description == Content)
            {
                task removal = task_List[task_List.IndexOf(temp)];
                task_List.RemoveAt(task_List.IndexOf(temp));
                removal.destroy_Task();
                return;
            }

        }
        return;
    }
    public static void Empty() //clear all tasks and empty
    {
        foreach (task temp in task_List)
        {
            temp.destroy_Task();

        }

        task_List.Clear();
    }

    public void on_ClickIcon() //function if clicking the below icon
    {
        opened = !opened;
        if (!opened)
        {
            this.gameObject.transform.parent.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            this.gameObject.transform.parent.transform.localScale = new Vector3(1, 1, 1);
        }
    } 
}
