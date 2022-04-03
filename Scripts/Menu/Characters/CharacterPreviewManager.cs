using System;
using System.Collections;
using System.Collections.Generic;
using TD.Menu.Characters;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class CharacterPreviewManager : MonoBehaviour
{
    
    
 

    public Button useButton;
    public TextMeshProUGUI useButtonText;

    public GameObject characterPreviewSpot { get; set; }
    public GameObject characterPreviewParent { get; set; }

    public GameObject currentPreviewModel { get; set; }
    public Character currentPreviewCharacter { get; set; }



    public GameObject characterPreviewSlotPrefab;


    public static CharacterPreviewManager _instance { get; set; }


    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {

        characterPreviewSpot = GameObject.Find("CharacterPreviewSpot");
        characterPreviewParent = GameObject.Find("PreviewSection");
        
        
        
        foreach(Character character in CharacterManager.instance.characters)
        {
            
            GameObject slotPreview = Instantiate(characterPreviewSlotPrefab, Vector3.zero, Quaternion.identity);

            
            SlotManager slotManager = slotPreview.GetComponent<SlotManager>();
            
            slotManager.SetSlotDetails(character);
            
            slotPreview.transform.SetParent(transform);
        }
        


 
        
        useButton.onClick.AddListener(OnUseButton);
        
   
    }





    private void OnUseButton()
    {
        CharacterManager.instance.usedCharacter = currentPreviewCharacter;
        useButton.interactable = false;
        useButtonText.text = "Using";
    }

  
}
