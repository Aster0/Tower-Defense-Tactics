using TD.Game;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{

    private Button button;
    private TD.Game.GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        gameManager = TD.Game.GameManager.Instance;

        button.onClick.AddListener(OnButtonClick);


        this.gameObject.SetActive(false);
    }

    private void OnButtonClick()
    {
        gameManager.InfoBox.SetActive(true);
        InfoBoxManager info = gameManager.InfoBox.GetComponent<InfoBoxManager>();


      
        info.UpdateUI();

  

       



    }

  
}
