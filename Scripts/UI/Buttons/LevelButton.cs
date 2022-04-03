using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI level;
    public GameObject lockImage;

    private Button _button;

    private LevelDetailsManager _levelDetailsManager;

    private LobbyManager _lobbyManager;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _levelDetailsManager = LevelDetailsManager.instance;
        _lobbyManager = LobbyManager.Instance;
        
        
        _button.onClick.AddListener(OnLevelChoose);

    }


    public void CheckIfUnlocked(int playerLevel, int maxLevel)
    {
        int currentLevel;

        try
        {
            currentLevel = Int32.Parse(level.text);
        }
        catch (Exception e)
        {
            currentLevel = 0;
        }
      
        
        if(playerLevel >= currentLevel && currentLevel <= maxLevel)
            lockImage.SetActive(false);
        else
            lockImage.SetActive(true);
        
        
        
    }

    private void OnLevelChoose()
    {
        if (lockImage.activeSelf)
        {
            return;
        }
        
        
        int levelClicked;
        try
        {
            levelClicked = int.Parse(level.text);
        }
        catch (FormatException levelNotFound)
        {
            levelClicked = 0;
        }
        
        
        _levelDetailsManager.ShowLevelDetails(levelClicked);
        
        
        if(_lobbyManager.rewardDetails.loaded)
            _lobbyManager.rewardDetails.gameObject.SetActive(false);
       
    }

}
