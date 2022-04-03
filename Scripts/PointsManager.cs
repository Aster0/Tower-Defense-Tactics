using System.Collections;
using System.Collections.Generic;
using TD.Game;
using TD.Menu.Characters;
using UnityEngine;

public class PointsManager : MonoBehaviour
{

    private TD.Game.GameManager _gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = TD.Game.GameManager.Instance;

        if (_gameManager != null)
        {
            _gameManager.Player = Instantiate(CharacterManager.instance.usedCharacter.targetModel, 
                new Vector3(21.99217f, -2.49f, 3.132733f), Quaternion.identity);

            _gameManager.playerComponent = _gameManager.Player.GetComponent<Player>();
            _gameManager.playerAnimator = _gameManager.Player.GetComponent<Animator>();
            _gameManager.playerMovement = _gameManager.Player.GetComponent<TD.Game.PlayerMovement>();
            
            _gameManager.LoadPoints();
            Debug.Log("Successfully loaded " + _gameManager.Points.Length + " waypoints on this map!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
