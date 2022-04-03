using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




namespace TD.Game
{
    [System.Serializable]
    public class DialogueManager : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {


        public static DialogueManager instance { get; set; }

        public LinkedList<Dialogue.Sentence> dialogueQueue { get; set; }
        public TextMeshProUGUI mText, clickToContinueText, titleText;


        public Image icon;

     
        private Dialogue dialogue { get; set; }

        private bool ready;

        private float oldDialogueSpeed;


        public OptionManager optionManager;
        private Dialogue.Sentence currentDialogue;
        


        public float speed, fastSpeed;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

                oldDialogueSpeed = speed;
                dialogueQueue = new LinkedList<Dialogue.Sentence>();

            

            }
        }




        public bool StartDialogue(Dialogue dialogue)
        {

            if (dialogue.dialogues.Count == 0)
                return false;


            this.dialogue = dialogue;

            this.gameObject.SetActive(true);


            titleText.SetText(dialogue.title);
            icon.sprite = dialogue.icon;


            dialogueQueue.Clear();

            foreach (Dialogue.Sentence sentence in dialogue.dialogues)
            {
                
                dialogueQueue.AddLast(sentence);
            }



            StartDialogueCoroutine();


            return true;


        }


        public IEnumerator NextDialogue()
        {
            if(dialogueQueue.Count != 0)
            {
                ready = false;
                StringBuilder sb = new StringBuilder(); // mutable, save memory rather than adding onto a string.
                currentDialogue = dialogueQueue.First.Value;
                dialogueQueue.RemoveFirst();
                
                
                optionManager.gameObject.SetActive(false);

                clickToContinueText.gameObject.SetActive(false);

                foreach (char letter in currentDialogue.sentence)
                {
                    mText.SetText(sb.Append(letter).ToString());

               
                    yield return new WaitForSeconds(speed);
                }

       
                clickToContinueText.SetText("Click to Continue");
                
      
                
                if (currentDialogue.type == Dialogue.QuestionType.Question)
                {
                
                    optionManager.gameObject.SetActive(true);
                    
                    clickToContinueText.SetText("Choose an Option");
                    
            
         

               
                    optionManager.UpdateOptions(currentDialogue.options);



                }
                
                clickToContinueText.gameObject.SetActive(true);
                ready = true;
            }
            else
                this.gameObject.SetActive(false);




        }

        public void StartDialogueCoroutine()
        {
            StartCoroutine(NextDialogue());
        }

        public void OnPointerClick(PointerEventData eventData)
        {




            if (ready && currentDialogue.type != Dialogue.QuestionType.Question)
                StartDialogueCoroutine();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(!ready) // in the midst of typing
            {
                speed = fastSpeed;
            }
        }



        public void OnPointerUp(PointerEventData eventData)
        {
            speed = oldDialogueSpeed;
        }
    }
}



