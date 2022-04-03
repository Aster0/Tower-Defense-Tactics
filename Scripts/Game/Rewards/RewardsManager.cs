using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class RewardsManager : MonoBehaviour
{



    public static RewardsManager instance { get; set; }
    



    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public TD.Game.Level LoadLevel(int level)
    {
        TD.Game.Level levelObj = (TD.Game.Level) Resources.Load("Objects/Levels/Level" + level);

     
        return levelObj;

    }
}
