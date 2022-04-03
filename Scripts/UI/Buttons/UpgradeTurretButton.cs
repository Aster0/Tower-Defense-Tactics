using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TD.Game;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTurretButton : MonoBehaviour
{

    private Button _button;

    private InfoBoxManager _infoBoxManager;
    
    private readonly int  UPGRADE_INCREMENT = 5;

    [SerializeField] private UpgradeType upgradeType;

    [SerializeField] private Slider slider;

    private TD.Game.GameManager _gameManager;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        _gameManager = TD.Game.GameManager.Instance;
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnTurretUpgrade);

        _infoBoxManager = _gameManager.InfoBox.GetComponent<InfoBoxManager>();

        player = _gameManager.Player;
    }

    private void OnTurretUpgrade()
    {
        if (slider.value != slider.maxValue)
        {

        
  

            TurretBase turret = _infoBoxManager.turret.GetComponent<TurretBase>();
            
  
            
            if (_gameManager.CurrencyManager.GetTotalAmount() >= turret.upgradePrice) // got money
            {
                
                
                if (upgradeType == UpgradeType.Damage)
                {
                    turret.damage += UPGRADE_INCREMENT;
                }
                else if (upgradeType == UpgradeType.Range)
                {
                    turret.shootRadius += UPGRADE_INCREMENT;
                    turret.UpdateRadiusCircle();
                }

                slider.value += UPGRADE_INCREMENT;
            
                
                _gameManager.CurrencyManager.RemoveCurrency(turret.upgradePrice);
            }
            else
            {
                DamageIndicatorHandler.Create(player, "Not enough money!", Color.red, 2);
            }
            
            
            
        }
    }


    public enum UpgradeType
    {
        
        Damage, 
        Range
    }
}
