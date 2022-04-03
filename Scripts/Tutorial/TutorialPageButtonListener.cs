using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPageButtonListener : MonoBehaviour
{


    [SerializeField]
    private TutorialPageManager tutorialPageManager;
    
    private Button _button;
    
    private delegate void OnButtonClick();

    [SerializeField]
    private TutorialButtonTypes buttonType;

    [SerializeField]
    private Button buttonPrevious;
    
    [SerializeField]
    private TextMeshProUGUI buttonTitle;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();

        OnButtonClick onButtonClick;
        if (buttonType == TutorialButtonTypes.Next)
        {
            onButtonClick = OnButtonNext;
        }
        else  
        {
            onButtonClick = OnButtonPrevious;
        }
        
        
        _button.onClick.AddListener(delegate
        {
            onButtonClick();

        });
        
        
    }

    public void OnButtonNext()
    {

        if (tutorialPageManager.tutorialIndex != tutorialPageManager.GetTotalTutorialPages() - 1)
        {
            tutorialPageManager.tutorialIndex++;
            tutorialPageManager.UpdateTutorialPage();
        
            if(tutorialPageManager.tutorialIndex > 0)
                buttonPrevious.interactable = true;

            if (tutorialPageManager.tutorialIndex == tutorialPageManager.GetTotalTutorialPages() - 1)
            {
                buttonTitle.text = "DONE";
            }
        }
        else
        {
            Destroy(TD.Game.GameManager.Instance.preLoadItems);
            CustomSceneManager.instance.LoadScene("Scenes/TD/TD_Menu", false);
        }
       
        
        
    }

    public void OnButtonPrevious()
    {
        tutorialPageManager.tutorialIndex--;

        if (tutorialPageManager.tutorialIndex == 0)
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }
        
        tutorialPageManager.UpdateTutorialPage();
        buttonTitle.text = ">";
    }
    public enum TutorialButtonTypes
    {
        Next,
        Previous
    }
}
