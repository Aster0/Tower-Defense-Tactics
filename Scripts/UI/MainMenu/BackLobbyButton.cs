using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackLobbyButton : MonoBehaviour
{

    private Button button;

    private WorldMap _worldMap;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(OnLobbyBack);

        _worldMap = GameObject.Find("SceneManager").GetComponent<WorldMap>();
    }

    private void OnLobbyBack()
    {
        SceneManager.LoadScene("Scenes/Lobby_Scenes/House");
        SceneManager.LoadScene("Scenes/Lobby_Scenes/DedicatedUI", LoadSceneMode.Additive);

        GameManager.instance.UpdateDetails();

        _worldMap._gameAppObject.SetActive(true);
    }

  
}
