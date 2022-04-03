using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{



    private int  CURRENT_PLAYER_LEVEL = 6, MAX_PLAYABLE_LEVEL = 9;



    private List<LevelButton> _levelButtons;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GlobalUserData.GetInstance().GetInventoryValue("TowerDefence 1") +  "TOWER DEFENCE");
        CURRENT_PLAYER_LEVEL = GlobalUserData.GetInstance().GetInventoryValue("TowerDefence 1");
        foreach (Transform child in transform)
        {

            LevelButton levelButton = child.GetComponent<LevelButton>();



            levelButton.CheckIfUnlocked(CURRENT_PLAYER_LEVEL, MAX_PLAYABLE_LEVEL);
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
