using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RewardDetails : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI itemNameText, descriptionText;

    public bool loaded;


    private void Start()
    {
    
        this.gameObject.SetActive(false);

        loaded = true;

      

    }

    public void ShowDetails(string name, string description)
    {
        
     
        
        this.gameObject.SetActive(true);
        itemNameText.text = name;
        descriptionText.text = "\"" + description + "\"";
        

    }
}
