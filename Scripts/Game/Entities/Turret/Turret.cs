using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Turret", menuName = "TD/Turrets/New Turret", order = 1)]
public class Turret : ScriptableObject
{
    public Sprite iconSprite;

    public GameObject model;

    public string name, description;

    public int levelUnlock, purchasePrice;

    public float buildSpeed, shootCooldown, rotationSpeed, shootRadius, damage;

    public int upgradePrice;
    public EnemyType[] enemyTypes;


    private void OnEnable()
    {
        TurretBase turretBase = model.GetComponent<TurretBase>();


        if (turretBase != null)
        {
            turretBase.turretName = name;
            turretBase.purchasePrice = purchasePrice;
            turretBase.buildSpeed = buildSpeed;
            turretBase.description = description;
            turretBase.shootCooldown = shootCooldown;
            turretBase.shootRadius = shootRadius;
            turretBase.rotationSpeed = rotationSpeed;
            turretBase.damage = damage;
            turretBase.enemyTypes = enemyTypes;

            turretBase.upgradePrice = upgradePrice;
        }
   

    }




}
