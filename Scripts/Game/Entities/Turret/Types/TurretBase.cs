using System.Collections;
using System.Linq;
using TD.Game;
using UnityEngine;

public class TurretBase : TurretBehavior
{


    
    private float cooldown;

    private bool showDamage = true;

    private bool stunned;
    public bool mShowDamage { get { return showDamage; } set { showDamage = value;  } }

    public string turretName, description;

    public int purchasePrice;

    public float buildSpeed, shootCooldown, shootRadius, rotationSpeed, damage;

    private GameObject stunnedParticle;

    public int upgradePrice;
    public EnemyType[] enemyTypes;


    private void Start()
    {
        stunnedParticle = Resources.Load("Prefab/Turrets/StunnedParticle") as GameObject;
        UpdateRadiusCircle();
        
    }

    public void UpdateRadiusCircle()
    {
        radiusCircle.transform.localScale = new Vector3(shootRadius, -0.1587483f, shootRadius);
    }

    private void Update()
    {
       

        if(!(cooldown < 0))
            cooldown -= Time.deltaTime;

        
        if(!stunned)
            OnSenseEnemy();
     
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         
            TD.Game.GameManager.Instance.InfoIndicator.SetActive(true);

            other.GetComponent<Player>().inBuildRange = true;

            TD.Game.GameManager.Instance.InfoIndicator.GetComponent<InfoManager>().targetTurret = this;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TD.Game.GameManager.Instance.InfoIndicator.SetActive(false);
            other.GetComponent<Player>().inBuildRange = false;
            TD.Game.GameManager.Instance.InfoIndicator.GetComponent<InfoManager>().targetTurret = null;

            TD.Game.GameManager.Instance.InfoBox.SetActive(false);
        }
    }

    private void OnSenseEnemy()
    {


        Collider[] colliders = Physics.OverlapSphere(radiusCircle.transform.position, shootRadius - 2f, layerMask);


        float nearestDistance = float.MaxValue; // start with a max value because the distance is the furtherest so we can slowly narrow down later.


        float distance; // to save the distance of each collider found later in the playerAttackTransform range. 

        Collider nearestCollider = null; // set it to null first so later we can know if we found the nearestcollider or not


        foreach (Collider collider in colliders)
        {


            distance = (pivotObject.transform.position - collider.transform.position)
                .sqrMagnitude; // find the distance between the
            // player and the collider

            if (distance <= nearestDistance) // if distance is lower than the saved nearestdistance, we have found our new nearest.
            {



                nearestDistance = distance; // update the nearest distance so in the next iteration and upcoming ones,
                // we can check if this is indeed the nearest or there are more nearer ones to attack. 
                // the nearest collider will be attacked.

                nearestCollider = collider; // update the nearest collider



            }
        }

        if (nearestCollider != null)
        {

            EnemyBase enemyBase = nearestCollider.GetComponent<EnemyBase>();

            if (enemyTypes.Contains(enemyBase.type))
            {
                cooldown -= Time.deltaTime;


                Vector3 direction = nearestCollider.transform.position - pivotObject.transform.position;
                Quaternion rotation =
                    Quaternion.LookRotation(direction);


            
                pivotObject.transform.rotation = Quaternion.Slerp(pivotObject.transform.rotation, rotation,
                    rotationSpeed * Time.deltaTime);



                Vector3 vectorToCheck = gunBarrel.transform.forward;
                
       
                //Debug.DrawRay(gunBarrel.transform.position, vectorToCheck * direction.magnitude,  Color.red);


                RaycastHit hit;
                bool isHit = Physics.Raycast(gunBarrel.transform.position, vectorToCheck, out hit, direction.magnitude);



                if (isHit)
                {
                    if (cooldown < 0 && hit.collider.CompareTag("Enemy"))
                    {
                        HealthBarControl healthControl = enemyBase.healthControl;

                        healthControl.SetHealth(healthControl.GetCurrentHealth() - damage);


                        if (showDamage)
                            DamageIndicatorHandler.Create(nearestCollider.gameObject, damage);

                        cooldown = shootCooldown;

                        OnShoot(nearestCollider.gameObject); // override method


                        Destroy(
                            Instantiate(hitParticles, nearestCollider.gameObject.transform.position + new Vector3(0, 0.5f),
                                Quaternion.identity), 3);

                        foreach (ParticleSystem sparks in sparkParticles)
                        {
                            sparks.Play();
                        }
                    }
                }
             
            }



        }

    }


    public void DisableTurret(int seconds)
    {
        stunned = true;
        Destroy(Instantiate(stunnedParticle, transform.position, Quaternion.identity), seconds);

        StartCoroutine(UnDisableTurret(seconds));
    }

    private IEnumerator UnDisableTurret(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        
        stunned = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(radiusCircle.transform.position, shootRadius - 2f);
    }


   




}
