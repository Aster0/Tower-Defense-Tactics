using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public RewardDetails rewardDetails;
    public static LobbyManager Instance { get; set; }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}
