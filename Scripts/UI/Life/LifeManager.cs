using System;
using System.Collections;
using System.Collections.Generic;
using TD.Game;
using TMPro;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    private TD.Game.GameManager _gameManager;

    [SerializeField]
    private TextMeshProUGUI mText;


    private void Start()
    {
        _gameManager = TD.Game.GameManager.Instance;
        SetAmount(GlobalUserData.GetInstance().GetInventoryValue("life"));
    }

    public void SetAmount(int amount)
    {
        mText.SetText(amount.ToString());
    }

    public int GetTotalAmount()
    {
        return int.Parse(this.mText.text);
    }


    public void GainCurrency(int amount)
    {
        SetAmount(GetTotalAmount() + amount);
    }

    public void RemoveCurrency(int amount)
    {
        SetAmount(GetTotalAmount() - amount);
        DamageIndicatorHandler.Create(_gameManager.Player, "-" + amount, Color.cyan, 3);
    }
}