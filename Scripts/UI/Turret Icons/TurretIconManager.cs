using TD.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretIconManager : MonoBehaviour
{

    [Header("Turret Information")]
    public Turret turret;


    [Header("Other Information")]
    public Image icon, lockedIcon;
    public TextMeshProUGUI name, price;

    [HideInInspector] public bool locked = true;


    public bool UnlockTurret()
    {
        if (turret != null)
        {

            if(TD.Game.GameManager.Instance.Level >= turret.levelUnlock)
            {
                lockedIcon.gameObject.SetActive(false);

                icon.gameObject.SetActive(true);

                icon.sprite = turret.iconSprite;

                name.text = turret.name;
                price.text = turret.purchasePrice.ToString();
                locked = false;

                return true;
            }
         
        }

        return false;

    }

 
}
