using System;
using System.Collections;
using System.Collections.Generic;
using TD.Game;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New Reward", menuName = "TD/Rewards/New Reward", order = 1)]
public class Reward : ScriptableObject
{


    public RewardDetails rewardDetails;

    private void Awake()
    {
        if (rewardDetails.maxAmount == 0)
        {
            rewardDetails.maxAmount = Int32.MaxValue;
         
        }
    }


    [Serializable]
    public class RewardDetails
    {
        public string name;
        public int amount;
        public Sprite sprite;
        public RewardType rewardType;
        public int rarity;
        public string description;

        public int maxAmount; 
        

        


        public void BuildReward()
        {
            GameObject rewardItem = Instantiate(ResultManager.instance.rewardItem,
                new Vector3(0,0), Quaternion.identity);
            

            rewardItem.transform.SetParent(ResultManager.instance.rewardParent.transform);

            rewardItem.transform.localScale = new Vector3(1, 1);


            RewardIconManager rewardIconManager = rewardItem.GetComponent<RewardIconManager>();

            rewardIconManager.image.sprite = sprite;
            


            
            amount *= rarity;


            if (amount > maxAmount)
                amount = maxAmount;
            
            rewardIconManager.quantity.SetText(amount.ToString());


            for (int i = 0; i < rarity; i++)
            {
                rewardIconManager.stars[i].SetActive(true);
            }
            
            
            
            OnRewardReceive(amount);
            
            
        }

        private void OnRewardReceive(int amount)
        {
            if (rewardType == RewardType.Currency)
            {
                // Add to global currency.
                
                GlobalUserData.GetInstance().SetInventoryValue("Coins", 
                    GlobalUserData.GetInstance().GetInventoryValue("Coins") + amount);

            }
            else if (rewardType == RewardType.Inventory)
            {
                // store in inventory.
            }
            else if (rewardType == RewardType.Life)
            {
                // store in inventory.
                GlobalUserData.GetInstance().SetInventoryValue("Life", 
                    GlobalUserData.GetInstance().GetInventoryValue("Life") + amount);
            }
        }


        public enum RewardType
        {
            Currency,
            Inventory,
            Life
        }
    }
 
}
