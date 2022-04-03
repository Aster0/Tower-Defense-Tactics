using System;
using System.Collections;
using System.Collections.Generic;
using TD.Game;
using Unity.VisualScripting;
using UnityEngine;




[CreateAssetMenu(fileName = "New Dialogue", menuName = "TD/Dialogues/New Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{

    public string title;
    public Sprite icon;
    public List<Sentence> dialogues;

    public int level;


    public bool LoadDialogue()
    {
     
        if (TD.Game.GameManager.Instance.Level == level)
            return true;
         
        

        return false;
    }



    [Serializable]
    public class Sentence
    {

        public QuestionType type;
        public string sentence;

   
        public Option[] options = new Option[2];

        
        
        [Serializable]
        public class Option
        {
            public string option;
            public bool correct;
            public string response;



        }

    }
    

    public enum QuestionType
    {
        Normal,
        Question
    }
  
}



