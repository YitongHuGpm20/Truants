using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
///Created in 11/01/2019 by Zijie Zhang
/////---<Purpose>---
//The purpose of this script is to allocate each gameobject in notebook for keywords
//---</Purpose>---

//---<LOGS>---

//10/01/2019
//Created a simple notebook to store the keyword


//---</LOGS>---

//---<Bugs or Questions in Mind>---
//1.characters variables
//---</Bugs or Questions in Mind>---
public static class Notebook_Base //static class
{
    private static List<Characters> Characters_List = new List<Characters>(); //list of characters

    public class Characters //class for characters
    {
        public string name; //name
        public List<string> Keyword_List;//their keywords storage

        public Characters(string Input_Name) //constructor
        {

            this.name = Input_Name;
            Keyword_List = new List<string>();
        }

        public override string ToString()//override the tostring for name
        {
            return this.name;
        }

        //public override bool Equals(object obj)
        //{
        //    //if (obj == null || !(obj is Characters))
        //    //    return false;
        //    //else if (obj is Characters && ((Characters)obj).name == this.name)
        //    //    return true;
        //    //else if (obj is string && ((string)obj) == this.name)
        //    //    return true;

        //    //return false;
        //}
        

        //overiding the checking equal, not sure needed in the future


    }

    public static Characters Create_Characters(string Input_Name) //create new character and add to list
    {
        if (!(Characters_List.Any(n => n.name == Input_Name)))
        {
            Characters New_Character = new Characters(Input_Name);
            Characters_List.Add(New_Character);
            return New_Character;
        }
        else
        {
            return (Characters_List.Find(n => n.name == Input_Name));
        }
    }

    public static void Add_Keyword_ToCharacter(string Character, string Keyword)
    {
        Characters temp = Create_Characters(Character);
        if (!temp.Keyword_List.Contains(Keyword))
            temp.Keyword_List.Add(Keyword); //add keyword to the character
    }

    public static void Show_Content() //debug function that shows everykeyword on every character
    {
        string content = "";
        foreach(Characters character in Characters_List)
        {
            content = character.name;

            foreach(string keyword in character.Keyword_List)
            {
                content = content + " " + keyword;
            }
            Debug.Log(content);
        }
    }

}
