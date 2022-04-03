using System;
using System.Collections;
using System.Collections.Generic;
using TD.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    private Slider _slider;
    public Gradient gradient;
    public Image health;

    public Slider backSlider;


    private Coroutine _animateCoroutine;

    public GameObject parentGameObject;

    public TextMeshProUGUI mName;

    private float _backSliderHealth;

    private TD.Game.GameManager _gameManager;

    private void Awake()
    {
        _slider = GetComponent<Slider>();



    }

    private void Start()
    {
        _gameManager = TD.Game.GameManager.Instance;



    }

    public void SetName(string name)
    {
        mName.SetText(name);
    }


    public float GetCurrentHealth()
    {
        return _slider.value;
    }

    public void SetMaxHealth(int maxHealth)
    {
   
        _slider.maxValue = maxHealth;
        backSlider.maxValue = maxHealth;

        _slider.value = maxHealth;
        backSlider.value = maxHealth;

        health.color = gradient.Evaluate(1f);


    }

    private void Die(GameObject gameObject)
    {

      
        


        if (gameObject.CompareTag("Enemy"))
        {
            EnemyBase enemyBase = parentGameObject.GetComponent<EnemyBase>();

            int currencyDrop = enemyBase.currencyDrop;
            
            Vector3 position = gameObject.transform.position;
            Destroy(gameObject);

            Destroy(Instantiate( _gameManager.deathParticles, position, Quaternion.identity), 2);

            GameObject currency = Instantiate( _gameManager.currency, position + new Vector3(0, 0.2f), Quaternion.identity);

            
            
            if(enemyBase.behavior != null)
                enemyBase.behavior.OnDeath(parentGameObject); // overriden method for different enemies to have different death behaviors
            
            currency.GetComponent<CurrencyPickup>().currency = new Currency(currencyDrop);

            Destroy(currency, 5);
        }
        else if (gameObject.CompareTag("Player"))
        {
            ResultManager.instance.HandleResults(0);

           
        }
    }

    public void SetHealth(float newHealth)
    {

        if(newHealth <= 0)
        {

            if (parentGameObject == null)
            {
                parentGameObject = _gameManager.Player;
   
            }

            Die(parentGameObject);


        }
        
        _slider.value = newHealth;
  
     

        health.color = gradient.Evaluate(_slider.normalizedValue);


        _backSliderHealth = newHealth;


        if (_animateCoroutine != null)
            StopCoroutine(_animateCoroutine);
        
        
        _animateCoroutine = StartCoroutine(AnimateBackSliderHealth());




    }


    private IEnumerator AnimateBackSliderHealth()
    {
      
        while (backSlider.value >= _backSliderHealth)
        {

            backSlider.value -= Time.deltaTime * 20;



            yield return null;
        }


        backSlider.value = _backSliderHealth;

        _animateCoroutine = null;


    }


}
