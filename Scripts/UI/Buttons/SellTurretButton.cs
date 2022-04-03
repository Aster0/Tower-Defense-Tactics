using System.Collections;
using System.Collections.Generic;
using TD.Game;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SellTurretButton : MonoBehaviour
{

    private Button button;
    private TD.Game.GameManager _gameManager;
    private Player player;

    private InfoBoxManager infoBoxManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = TD.Game.GameManager.Instance;
     
        infoBoxManager = transform.parent.parent.parent.GetComponent<InfoBoxManager>();
        button = GetComponent<Button>();
        
        button.onClick.AddListener(OnTurretSell);
    }

    private void OnTurretSell()
    {
        _gameManager.CurrencyManager.GainCurrency(int.Parse(infoBoxManager.sellGold.text));

        _gameManager.playerComponent.inBuildRange = false;
        
        DamageIndicatorHandler.Create(_gameManager.playerComponent.gameObject, "+" +
            infoBoxManager.sellGold.text, Color.green, 3);
        
        Destroy(infoBoxManager.turret);
        infoBoxManager.CloseUI();
    }

}
