using System;
using System.Collections;
using TD.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveUIManager : MonoBehaviour
{

    private readonly string waveText = "Wave: ";
    private readonly string enemyText = " Enemies Remaining";
    public TextMeshProUGUI enemyRemaining, waveRemaining;

    private Slider waveSlider;

    private int _totalEnemies;
    
    public int totalEnemiesNotSpawned { get; set; }
    
    private IEnumerator AnimateSlider()
    {
      
        while (waveSlider.value <= _totalEnemies - GetRemainingEnemies())
        {

            waveSlider.value += Time.deltaTime * 0.5f;



            yield return null;
        }

        

        


    }


    public void SetEnemiesRemaining(int enemies, bool animateSlider)
    {
        
        
 



        if(animateSlider)
            StartCoroutine(AnimateSlider());
        
        
        

        if (enemies == 0)
        {
            TD.Game.GameManager.Instance.WaveManager.OnWaveEnd();
            
            
        }
     
        enemyRemaining.SetText(enemies + enemyText);
    
        
    }


    public void SetMaxEnemiesRemaining(int enemies)
    {
        _totalEnemies = enemies;
        SetEnemiesRemaining(enemies, false);
        waveSlider.maxValue = enemies;

        totalEnemiesNotSpawned = enemies;
    }
    
    public int GetRemainingEnemies()
    {
        return int.Parse(enemyRemaining.text.Replace(enemyText, ""));
    }
    
    public void SetWaveRemaining(string waves)
    {
        waveRemaining.SetText(waveText + waves);
    }

    public int[] GetRemainingWaves()
    {


        return Array.ConvertAll(waveRemaining.text.Replace(waveText, "").Split('/'),
            str => int.Parse(str));
    }


    private void Start()
    {
        waveSlider = GetComponent<Slider>();
        waveSlider.value = 0;
    }
}
