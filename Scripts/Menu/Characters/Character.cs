using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TD.Menu.Characters
{
    
    [CreateAssetMenu(fileName = "New Character", menuName = "TD/Characters/New Character", order = 1)]
    public class Character : ScriptableObject
    {
        public new string name;

        public int cost;
        public GameObject targetModel;

        public Sprite previewImage;
    }

}
