using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardIconManager : MonoBehaviour
{

    public Reward reward;
    public GameObject[] stars;

    public TextMeshProUGUI quantity;

    public Image image;


    private void Awake()
    {
        System.Array.Sort(stars, 
            (x, y) => string.Compare(x.name, y.name));

    }

   
}
