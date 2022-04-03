using UnityEngine;

public class CurrencyPickup : MonoBehaviour
{

    public Currency currency { get; set; }

    private CurrencyManager currencyManager;
    private void Start()
    {
        currencyManager = TD.Game.GameManager.Instance.CurrencyManager;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

      

            currencyManager.GainCurrency(currency.amount);
        }
    }
}
