using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace TD.Menu.Characters
{
    public class CharacterManager : MonoBehaviour
    {
    
    
        public List<Character> characters { get; set; }
        public static CharacterManager instance { get; set; }


        private CharacterPreviewManager _characterPreviewManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            _characterPreviewManager = CharacterPreviewManager._instance;
            
            Object[] characterObjects = Resources.LoadAll("Objects/Characters", typeof(Character));


          
            characters = new List<Character>();

            foreach (Object obj in characterObjects)
            {

                Character character = (Character) obj;
            
                characters.Add(character);
            
             

            
            }

            SetDefaultCharacter();

        }
        
        private void SetDefaultCharacter()
        {
            if (usedCharacter == null)
            {
                usedCharacter = characters[0];
            }
        }


        public Character usedCharacter { get; set; }
    }
}

