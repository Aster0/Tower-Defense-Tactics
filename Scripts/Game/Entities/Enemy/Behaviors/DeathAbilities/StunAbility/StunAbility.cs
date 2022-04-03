using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;


public class StunAbility : EnemyBehavior
{

    private GameObject stunParticles;

    public int chance = 20;

    public int abilityRange = 2, abilityDuration = 3;
    
    private void Start()
    {
        stunParticles = Resources.Load("Prefab/Enemies/Abilities/StunParticle") as GameObject;
        
      
    }

    public override void OnDeath(GameObject enemy)
    {
        Debug.Log("Before base");
        base.OnDeath(enemy);


        int random = Random.Range(1, 101); 


        if (random <= chance)
        {
            Destroy(Instantiate(stunParticles, enemy.transform.position + new Vector3(0, 0.5f), Quaternion.identity), 3);


            Collider[] colliders = Physics.OverlapSphere(transform.position, abilityRange);


            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Turret"))
                {
                    collider.GetComponent<TurretBase>().DisableTurret(abilityDuration);
                }
            }
        }
        
        


    }
}
