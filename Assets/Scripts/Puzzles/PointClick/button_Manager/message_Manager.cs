using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Created in 10/02/2019 by Zijie Zhang
//---<Purpose>---
//This script is to create manager for messege in point and click puzzles
//---</Purpose>---

//---<LOGS>---

//10/02/2019
//Created for message manager


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//---</Bugs or Questions in Mind>---
public class message_Manager : MonoBehaviour
{
    public Text name; //speaker's name
    public Text message; //speaker's message

    public Animator animate; //animation
    public Queue<string> sentences;//list of speaker's sentences

    private void Start()
    {
        sentences = new Queue<string>(); //create a new queue
    }

    public void start_Message(message mes)
    {
        //Debug.Log(mes.human_Name);
        name.text = mes.human_Name; //set name
        sentences.Clear(); //clear sentence
        foreach (string temp in mes.sentences)
            sentences.Enqueue(temp); //put in queue
        display_Next_Sentence(); //display the first message
    }

    public void display_Next_Sentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
        {
            end_Message();
            return; //if sentences are 0, end
        }
        string sentence = sentences.Dequeue(); //dequeue
        StopAllCoroutines();//stop typing animation
        StartCoroutine(type_Sentence(sentence)); //start typing next sentence
    }

    IEnumerator type_Sentence(string sentence)
    {
        message.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return null; //type writing sentence
        }
    }

    public void end_Message()
    {

    }
}
