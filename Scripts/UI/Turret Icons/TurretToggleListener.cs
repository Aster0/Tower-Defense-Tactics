using TD.Game;
using UnityEngine;
using UnityEngine.UI;

public class TurretToggleListener : MonoBehaviour
{

    private Toggle toggle;

    private InfoManager info;

    public TurretToggleTypes type;
    // Start is called before the first frame update
    void Start()
    {

        info = TD.Game.GameManager.Instance.InfoIndicator.GetComponent<InfoManager>();
        toggle = GetComponent<Toggle>();

        toggle.onValueChanged.AddListener(OnToggle);
    }

    private void OnToggle(bool value)
    {
        TurretBase turret = info.targetTurret.GetComponent<TurretBase>();


        if (type == TurretToggleTypes.DAMAGE_INDICATOR)
        {
          
            turret.mShowDamage = value;


        }
        else if (type == TurretToggleTypes.TURRET_AREA)
        {
            turret.radiusCircle.SetActive(value);
        }
    }
}
