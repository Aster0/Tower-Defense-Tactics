using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TD.Game;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviour
{
    
    

    private int _maxRewards;


    private List<Enemy> enemies;

    private TD.Game.Level.RewardPerLevel _rewardForLevel;
    private TD.Game.Level levelDetails;

    public bool started { get; set; }

    private int _currentWave = 1, _totalEnemies, _totalWaves;



    private Coroutine _spawnCoroutine;


    private float _waveSpawnRate;

    private TD.Game.GameManager _gameManager;

    private StartWaveButton _startWaveButton;




    public void OnWaveStart()
    {





        _totalEnemies = _currentWave * 20;
        
        _gameManager.WaveUIManager.SetMaxEnemiesRemaining(_totalEnemies);

        
        
        _waveSpawnRate = 10 / (float) _currentWave;
        
        started = true;

        _spawnCoroutine = StartCoroutine(SpawnEnemies());









    }


    private void OnResults()
    {
        if (_currentWave == _totalWaves + 1)
        {

            if (GlobalUserData.GetInstance().GetInventoryValue("TowerDefence 1") == levelDetails.level)
            {
                GlobalUserData.GetInstance().SetInventoryValue("TowerDefence 1",
                    GlobalUserData.GetInstance().GetInventoryValue("TowerDefence 1") + 1);
            }

            int stars;

            HealthBarControl playerHealth = _gameManager.playerComponent.healthBarControl;
        

            if (playerHealth.GetCurrentHealth() >= 80)
            {
                stars = 3;
            }
            else if (playerHealth.GetCurrentHealth() >= 50 && playerHealth.GetCurrentHealth() < 80)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }
            
            ResultManager.instance.HandleResults(stars);

            _maxRewards = _gameManager.Level * _rewardForLevel.maxRewardMultiplier;

            foreach (Reward reward in _rewardForLevel.rewards)
            {
                int rewardsToGive = Random.Range(1, _maxRewards + 1);

          

                Reward.RewardDetails rewardDetails = reward.rewardDetails;

                
                int rarity = Random.Range(1, stars + 1); // 1-3
                
          

                rewardDetails.rarity = rarity; // 1-3
                rewardDetails.amount = rewardsToGive;
                
                rewardDetails.BuildReward();
                
            }
        }
    }
    public void OnWaveEnd()
    {
        _currentWave++;
        UpdateWaveUI();
        
        _startWaveButton.SetInformationStart(1, "Start Wave", 1);
        
        started = false;
        
        Debug.Log("Wave End");

        StopCoroutine(_spawnCoroutine);


        OnResults();
    }

    private void UpdateWaveUI()
    {
        _gameManager.WaveUIManager.SetWaveRemaining(_currentWave + "/" + _totalWaves);
    }

    public void ResetLevel()
    {

        OnWaveEnd();
        
        
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
      
            Destroy(enemy);
        }

        _gameManager.playerComponent.healthBarControl.SetHealth(_gameManager.playerComponent.healthBarControl.backSlider.maxValue);
        
        _currentWave = 1;
        UpdateWaveUI();
    }




    public void Start()
    {
        
      
        
        BuildInitialWave();
        
        
        
        levelDetails = RewardsManager.instance.LoadLevel(_gameManager.Level);
        _rewardForLevel = levelDetails.levelRewardDetails;
        
        GetEnemies();


    }

    private void GetEnemies()
    {
        enemies = new List<Enemy>();

        TD.Game.Level.Enemies[] waveEnemies = levelDetails.enemies;

        foreach (TD.Game.Level.Enemies enemy in waveEnemies)
        {
            for (int i = 0; i < enemy.chance; i++)
            {
                enemies.Add(enemy.enemy);
            }
        }

    
    }

    public void BuildInitialWave()
    {
        _gameManager = TD.Game.GameManager.Instance;

       

        _startWaveButton = GameObject.FindGameObjectWithTag("StartWaveButton").GetComponent<StartWaveButton>();
        
        _totalWaves = _gameManager.Level * 2;
        _gameManager.WaveUIManager.SetWaveRemaining("1/" + _totalWaves);
    }



    private IEnumerator SpawnEnemies()
    {


        while(started)
        {
            
            
            Debug.Log("Started " + _gameManager.WaveUIManager.totalEnemiesNotSpawned);


            if (_gameManager.WaveUIManager.totalEnemiesNotSpawned > 0)
            {
               
                Debug.Log("Total Enemies Spawned more than 0");
         
                int randomNumber = Random.Range(0, enemies.Count);

        

          



                GameObject randomEnemy = enemies[randomNumber].model;

         

                Instantiate(randomEnemy, _gameManager.StartPoint.transform.position, Quaternion.identity);



                _gameManager.WaveUIManager.totalEnemiesNotSpawned -= 1;


            }
            
            //_gameManager.WaveUIManager.SetEnemiesRemaining(
              //  _gameManager.WaveUIManager.GetRemainingEnemies() - 1, true);
            
            

            yield return new WaitForSeconds(_waveSpawnRate);

        }


        
    }

}
