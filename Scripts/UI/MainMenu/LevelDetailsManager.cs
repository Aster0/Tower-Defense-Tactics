using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDetailsManager : MonoBehaviour
{


    private int MAX_STARS = 3;
    private int MAX_RARITY = 3;
    public static LevelDetailsManager instance { get; set; }

    private LevelManager _levelManager;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            gameObject.SetActive(false);
            
            _levelManager = LevelManager.instance;
        }
    }

    [SerializeField] private GameObject rewardItem, rewardParent;
    [SerializeField] private TextMeshProUGUI levelText;


    public void ShowLevelDetails(int level)
    {
        gameObject.SetActive(true);

        _levelManager.chosenLevel = level;

        TD.Game.Level.RewardPerLevel rewardForLevel = RewardsManager.instance.LoadLevel(level).levelRewardDetails;

        String levelTitle = "Level " + level;
        
        if (GlobalUserData.GetInstance().GetInventoryValue("Life") == 0)
        {

            levelTitle = "Not Enough Lives to Play!";
        }
        
        levelText.SetText(levelTitle);

        foreach (Transform child in rewardParent.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Reward reward in rewardForLevel.rewards)
        {
            GameObject rewardObject = Instantiate(rewardItem, new Vector3(0, 0), Quaternion.identity);

            RewardIconManager rewardIconManager = rewardObject.GetComponent<RewardIconManager>();

            rewardIconManager.reward = reward;

            rewardIconManager.image.sprite = reward.rewardDetails.sprite;


            int amount = level * rewardForLevel.maxRewardMultiplier * MAX_RARITY;


            if (amount > reward.rewardDetails.maxAmount)
            {
                amount = reward.rewardDetails.maxAmount;
            }
            
            rewardIconManager.quantity.SetText(amount.ToString());
            
            rewardObject.transform.SetParent(rewardParent.transform);

           

        }
    }
    
 
}
