using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD.Game
{
    [CreateAssetMenu(fileName = "New Level", menuName = "TD/Levels/New Level", order = 1)]
    public class Level : ScriptableObject
    {
        public int level;

    
        public RewardPerLevel levelRewardDetails;

        public Enemies[] enemies;
    
        [Serializable]
        public class RewardPerLevel
        {
   
            public Reward[] rewards;
        
        
            public int maxRewardMultiplier;
        }


        [Serializable]
        public class Enemies
        {
            public Enemy enemy;
            public int chance;
        }
    }
}

