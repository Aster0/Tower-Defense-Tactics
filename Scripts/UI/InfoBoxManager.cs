using TD.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBoxManager : MonoBehaviour
{
    // Start is called before the first frame update

    public InfoManager info { get; set; }
    
    public TextMeshProUGUI name, description, sellGold, upgradePriceText;

    [SerializeField] private Slider attackSpeedSlider, rangeSlider, damageSlider, buildSlider;

    public GameObject turret;
    
    void Start()
    {
        info = TD.Game.GameManager.Instance.InfoIndicator.GetComponent<InfoManager>();

        CloseUI();




    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        
        if (info.targetTurret != null)
        {

            TurretBase target = info.targetTurret;
            
            turret = target.gameObject;
            
            name.SetText(target.turretName);
            attackSpeedSlider.value = target.shootCooldown;
            rangeSlider.value = target.shootRadius;
            buildSlider.value = target.buildSpeed;

            damageSlider.value = target.damage;
    
            upgradePriceText.SetText(target.upgradePrice.ToString());

            description.SetText("\"" + target.description + "\"");

            sellGold.SetText((target.purchasePrice / 2).ToString());




        }
    }

    
}
