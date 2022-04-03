using System.Collections;
using System.Collections.Generic;
using TD.Game;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonHandler : MonoBehaviour
{

    private Button _button;

    public Dialogue.Sentence.Option option;

    public GameObject cross;

    private TD.Game.DialogueManager _dialogueManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _dialogueManager = TD.Game.DialogueManager.instance;
        
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnOptionChosen);
    }


    private void OnOptionChosen()
    {
        
        if (!option.correct)
        {
            cross.SetActive(true);
            

            return;
        }

        Dialogue.Sentence sentence = new Dialogue.Sentence();
        sentence.sentence = option.response;
        sentence.type = Dialogue.QuestionType.Normal;
        
        _dialogueManager.dialogueQueue.AddFirst(sentence);
        _dialogueManager.StartDialogueCoroutine();
        
    }
   
}
