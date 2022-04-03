using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tutorial Pages", menuName = "TD/Tutorial/New Tutorial Pages", order = 1)]
public class TutorialPages : ScriptableObject
{



    public List<TutorialPage> tutorialPages;
    
    [Serializable]
    public class TutorialPage
    {
        public Sprite image;
        public string title, description;
    }

    

}
