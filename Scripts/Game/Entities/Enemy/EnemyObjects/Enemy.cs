using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "TD/Enemies/New Enemy", order = 1)]
public class Enemy : ScriptableObject
{

    public string entityName, description;

    public GameObject model;
    public EnemyBehavior behavior;
    public EnemyType type;
    public int health, speed, damageAfterCrossingEnd;
    public int currencyDrop;
 


    private EnemyBase _enemyBase;


    public void OnEnable()
    {
        behavior = model.GetComponent<EnemyBehavior>();
        
        
        _enemyBase = model.GetComponent<EnemyBase>();

        _enemyBase.entityName = entityName;
        _enemyBase.description = description;
        _enemyBase.health = health;
        _enemyBase.speed = speed;
        _enemyBase.currencyDrop = currencyDrop;
        _enemyBase.damageAfterCrossingEnd = damageAfterCrossingEnd;
        _enemyBase.type = type;

    }

}





public enum EnemyType
{

    A_Bacteria,
    B_Bacteria,
    Super_Bacteria,
    Virus
}
