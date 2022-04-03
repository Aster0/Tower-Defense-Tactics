using System;
using TD.Game;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{


    private int currentPointNavigating = 0;

    public string entityName;

    public EnemyBehavior behavior { get; set; }
    

    private NavMeshAgent agent;

    [Header("Enemy Information")]

    public int health, speed;
    public string description;
    public int currencyDrop;
    public int damageAfterCrossingEnd;

    public EnemyType type;


    private TD.Game.GameManager gameManager;



    public HealthBarControl healthControl;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = TD.Game.GameManager.Instance;
        agent = GetComponent<NavMeshAgent>();
        behavior = GetComponent<EnemyBehavior>();
   
        navigateNextPoint();



    

        healthControl.SetMaxHealth(health);
        healthControl.SetName(entityName);
    }

    // Update is called once per frame
    void Update()
    {


 
   
        if (transform.position.x == gameManager.Points[currentPointNavigating].transform.position.x &&
    transform.position.z == gameManager.Points[currentPointNavigating].transform.position.z)
        {

            navigateNextPoint();


         
        }
        
  
    
    }


    private void navigateNextPoint()
    {

        currentPointNavigating++;

        try
        {
            // tries to navigate to the next point, if it's a null then dont set destination.
            agent.SetDestination(gameManager.Points[currentPointNavigating].transform.position);
        }
        catch (IndexOutOfRangeException e) { // means its the last point and we should update the player's health.

            Player playerHealth = gameManager.Player.GetComponent<Player>();
            playerHealth.healthBarControl.SetHealth(playerHealth.healthBarControl.GetCurrentHealth() - damageAfterCrossingEnd);

            healthControl.SetHealth(0);
        }
    }





}
