using System.Collections;
using System.Collections.Generic;
using TD.Game;
using UnityEngine;
using UnityEngine.UI;

public class BackToMenuButton : MonoBehaviour
{

    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnBackToMenu);
    }


    private void OnBackToMenu()
    {
        Destroy(TD.Game.GameManager.Instance.preLoadItems);
        CustomSceneManager.instance.LoadScene("Scenes/TD/TD_Menu", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
