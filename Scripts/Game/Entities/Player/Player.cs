using System;
using TD.Game;
using UnityEngine;

public class Player : MonoBehaviour
{

    public ProgressBarController progressBarController;

    public bool inBuildRange { get; set; }

    public HealthBarControl healthBarControl { get; set; }

    public int startHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
        
            healthBarControl = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<HealthBarControl>();
            healthBarControl.SetMaxHealth(startHealth);
            
            GameObject progressObject = Instantiate(TD.Game.GameManager.Instance.playerUI, transform.position  + new Vector3(-0.04999966f, 2.6f, -0.1999999f),
                Quaternion.Euler(

                    new Vector3(37.5f, 181.606f, 5.6f)));
            
            progressObject.transform.SetParent(transform);
            progressObject.SetActive(false);

            progressBarController = progressObject.GetComponent<ProgressBarController>();

            
        }
        catch (Exception e)
        {
          
        }

    }

}
