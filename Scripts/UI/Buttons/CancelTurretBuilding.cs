using System.Collections;
using System.Collections.Generic;
using TD.Game;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CancelTurretBuilding : MonoBehaviour
{

    private Button _button;

    private TD.Game.GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = TD.Game.GameManager.Instance;
        
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(OnBuildCancel);
    }

    private void OnBuildCancel()
    {
        _gameManager.CurrentTurretBuildInstance.StopBuilding();
    }

}
