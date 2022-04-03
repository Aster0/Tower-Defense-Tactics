using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject levelCanvas, mainCanvas;


    [SerializeField] private Button playButton, backButton;

    private bool back = false;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnButtonClick);
        backButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
       
        if (!back)
            back = true;
        else
            back = false;
        
        levelCanvas.SetActive(back);
        mainCanvas.SetActive(!back);
        
    }
    
}
