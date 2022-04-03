using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnPlay);
    }


    private void OnPlay()
    {
    
        
        if (GlobalUserData.GetInstance().GetInventoryValue("Life") == 0)
        {

            return;
            
        }
        
        CustomSceneManager.instance.LoadScene("Scenes/TD/TD_Level" + LevelManager.instance.chosenLevel, true);
    }
}
