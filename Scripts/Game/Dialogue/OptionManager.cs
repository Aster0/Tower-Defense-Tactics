using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public TextMeshProUGUI[] optionTexts;
    public GameObject[] crosses;
    private Dialogue.Sentence.Option[] options;

    private List<OptionButtonHandler> _optionButtonHandlers;

    private Button _button1, _button2;
    // Start is called before the first frame update
    void Awake()
    {

        _optionButtonHandlers = new List<OptionButtonHandler>();
        
        for(int i = 0; i < optionTexts.Length; i++)
        {
            _optionButtonHandlers.Add(optionTexts[i].transform.parent.GetComponent<OptionButtonHandler>());

           
        }
        

        
    }


    public void UpdateOptions(Dialogue.Sentence.Option[] options)
    {
        this.options = options;
        

        int count = 0;

        foreach(TextMeshProUGUI text in optionTexts)
        {
            text.SetText(options[count].option);

           
            _optionButtonHandlers[count].option = options[count];

            crosses[count].SetActive(false);
            count++;

        }
    }


 
}
