using System;
using System.Collections;
using System.Collections.Generic;
using TD.Game;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    private TD.Game.GameManager _gameManager;

    [SerializeField]
    private TextMeshProUGUI mText;

    private GlobalUserData _globalUserData;


    private void Start()
    {
        _globalUserData = GlobalUserData.GetInstance();
        _gameManager = TD.Game.GameManager.Instance;
        SetAmount(GlobalUserData.GetInstance().GetInventoryValue("coins"));
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
        DamageIndicatorHandler.Create(_gameManager.Player, "+" + amount, Color.cyan, 3);
        UpdateWebAPI();
        
        Debug.Log("Gaining..");
    }

    public void RemoveCurrency(int amount)
    {
        SetAmount(GetTotalAmount() - amount);
        DamageIndicatorHandler.Create(_gameManager.Player, "-" + amount, Color.cyan, 3);
        
        UpdateWebAPI();
        
        Debug.Log("Removing..");
    }

    private void UpdateWebAPI()
    {
        _globalUserData.SetInventoryValue("coins", GetTotalAmount());
        
    }
}
