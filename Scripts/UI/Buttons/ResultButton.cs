using System.Collections;
using System.Collections.Generic;
using TD.Game;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour
{

    public ResultPressType resultPressType;
    private Button _button;

    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ResultManager.instance.HandleResults();

        if (resultPressType == ResultPressType.Continue)
        {
            
            if (text.text.Contains("Try Again"))
            {
                // make level to 1 again.
                Destroy(TD.Game.GameManager.Instance.preLoadItems);
                CustomSceneManager.instance.LoadScene(SceneManager.GetActiveScene().path, true);
            }
        }
    }


    public enum ResultPressType
    {
        
        Menu,
        Continue
    }
}
