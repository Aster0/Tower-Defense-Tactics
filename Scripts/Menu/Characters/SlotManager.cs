using System;
using System.Collections;
using System.Collections.Generic;
using TD.Menu.Characters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI cost, name;
    [SerializeField]
    private Image sprite;


    private GameObject targetModel;


    private Character character;
    private CharacterPreviewManager _characterPreviewManager;


    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnSlotPreview);
        _characterPreviewManager = CharacterPreviewManager._instance;

    }

    private void OnSlotPreview()
    {
        Debug.Log(CharacterPreviewManager._instance);

        if (_characterPreviewManager.currentPreviewModel != null)
        {
            Destroy(_characterPreviewManager.currentPreviewModel);
        }

        
        
        _characterPreviewManager.currentPreviewModel = Instantiate(targetModel, _characterPreviewManager.characterPreviewSpot.transform.position, 
            Quaternion.Euler(new Vector3(0, 180, 0)));
        
        _characterPreviewManager.currentPreviewModel.transform.SetParent(_characterPreviewManager.characterPreviewParent.transform);

        _characterPreviewManager.currentPreviewModel.transform.localScale = new Vector3(171, 171, 171);

        _characterPreviewManager.useButton.interactable = true;
        _characterPreviewManager.useButtonText.text = "Use";
        
        
        if (CharacterManager.instance.usedCharacter.name.Equals(name.text))
        {
            _characterPreviewManager.useButton.interactable = false;
            _characterPreviewManager.useButtonText.text = "Using";
        }

        _characterPreviewManager.currentPreviewCharacter = character;


    }

    public void SetSlotDetails(Character character)
    {
        this.sprite.sprite = character.previewImage;
        
        this.cost.SetText(character.cost.ToString());
        this.name.SetText(character.name);

        this.targetModel = character.targetModel;

        this.character = character;
    }
}
