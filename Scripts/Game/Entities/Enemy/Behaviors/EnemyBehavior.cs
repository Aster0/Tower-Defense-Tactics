using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public virtual void OnDeath(GameObject enemy)
    {
        
        TD.Game.GameManager.Instance.WaveUIManager.SetEnemiesRemaining(
            TD.Game.GameManager.Instance.WaveUIManager.GetRemainingEnemies() - 1, true);
        
    }




    }
