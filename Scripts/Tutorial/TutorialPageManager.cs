using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPageManager : MonoBehaviour
{

    [SerializeField]
    private TutorialPages _tutorialPages;

    [SerializeField]
    private TextMeshProUGUI title, description;

    [SerializeField] private Image image;


    public int tutorialIndex = 0;


    private void Start()
    {
        UpdateTutorialPage();
        
        GameObject.Find("Dialogue").gameObject.SetActive(false);
    }

    public void UpdateTutorialPage()
    {

        TutorialPages.TutorialPage tutorialPage = _tutorialPages.tutorialPages[tutorialIndex];
        
        title.text = tutorialPage.title;
        description.text = tutorialPage.description;
        image.sprite = tutorialPage.image;
    }


    public int GetTotalTutorialPages()
    {
        return _tutorialPages.tutorialPages.Count;
    }



}
