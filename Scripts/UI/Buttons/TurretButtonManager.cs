using System.Collections;
using TD.Game;
using UnityEngine;
using UnityEngine.UI;

public class TurretButtonManager : MonoBehaviour
{

    private TurretIconManager turretIconManager;
    private ProgressBarController progressBarController;


    private Turret turret;



    private Button button;

    private bool building;
    private TD.Game.GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
    
        turretIconManager = GetComponent<TurretIconManager>();

       
        
   

        button = GetComponent<Button>();


        button.onClick.AddListener(PlaceTurret);
        turret = turretIconManager.turret;

        gameManager = TD.Game.GameManager.Instance;
        
      


        
    }



    private void GetProgressBar()
    {
        progressBarController = gameManager.playerComponent.progressBarController;
    }

    private IEnumerator BuildProgressBar()
    {
        
     
        
        while(building)
        {
            

            progressBarController.SetProgress(progressBarController.GetProgress() + (Time.deltaTime * (150 / turret.buildSpeed)));


            if(progressBarController.GetProgress() >= 100)
            {
                if (!gameManager.playerComponent.inBuildRange)
                {
                    Instantiate(turret.model, gameManager.playerComponent.gameObject.transform.position + new Vector3(0, 0.2f), Quaternion.identity);


                    gameManager.CurrencyManager.RemoveCurrency(turret.purchasePrice);
            

                    Destroy(Instantiate(gameManager.buildParticle, 
                        gameManager.playerComponent.transform.position, Quaternion.identity), 2);

               
               
                    
                    gameManager.playerAnimator.SetBool("Building", false);
                    
                }
                else
                {
                    DamageIndicatorHandler.Create(gameManager.playerComponent.gameObject, "Too close to another turret!", Color.red, 2); // if the player walks around while building.
                }

                StopBuilding();

            }

            yield return null;
        }
    }

    public void StopBuilding()
    {
        

        
        gameManager.playerMovement.canMove = true;
        gameManager.playerAnimator.SetBool("Building", false);
        building = false;
        progressBarController.gameObject.SetActive(building);
    }


    private void PlaceTurret()
    {


        if (turretIconManager.locked)
        {
            DamageIndicatorHandler.Create(gameManager.playerComponent.gameObject, "Turret is locked!", Color.red, 2);
            return;
        }
        
        if(gameManager.CurrencyManager.GetTotalAmount() < turret.purchasePrice) // no money
        {

            DamageIndicatorHandler.Create(gameManager.playerComponent.gameObject, "Not enough money!", Color.red, 2);
            return;
        }

     




        if (!building)
        {

            GetProgressBar();
            if(!gameManager.playerComponent.inBuildRange)
            {
                gameManager.CurrentTurretBuildInstance = this;
                
                progressBarController.gameObject.SetActive(true);
                progressBarController.SetProgress(0);
                building = true;

                gameManager.playerMovement.canMove = false;
                
                gameManager.playerAnimator.SetBool("Building", true);
                StartCoroutine(BuildProgressBar());
                


                

          
            }
            else
            {
                DamageIndicatorHandler.Create(gameManager.playerComponent.gameObject, "Too close to another turret!", Color.red, 2);
            }
       
            
        }
       
    }
  
}
