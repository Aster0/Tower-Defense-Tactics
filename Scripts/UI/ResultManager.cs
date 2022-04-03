using System;
using System.Collections;
using System.Collections.Generic;
using TD.Game;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{

    public TextMeshProUGUI resultMessage, continuePlayingText;
    public GameObject rewardItem;

    public GameObject rewardParent;


    public GameObject[] stars;
    public GameObject burstAnimation;


    private readonly string SUCCESS_MESSAGE = "Sucessfully Defended";
    private readonly string FAIL_MESSAGE = "Uh oh! Try again!";



    private GlobalUserData _globalUserData;

    public static ResultManager instance { get; set; }


    private void Awake()
    {


        if (instance == null)
        {
            instance = this;
            _globalUserData = GlobalUserData.GetInstance();
            
            
            System.Array.Sort(stars, (x, y) => string.Compare(x.name, y.name));

            gameObject.SetActive(false);

        }
        


    }


    public void HandleResults()
    {

        
      
        
        if (TD.Game.GameManager.Instance.currentGameState == GameState.Results)
        {
            Time.timeScale = 1;
            
            gameObject.SetActive(false);
           
            TD.Game.GameManager.Instance.currentGameState = GameState.Playing;
          
            // switch back to GameState Playing.
        }

   

    }
    public void HandleResults(int stars)
    {



        if (TD.Game.GameManager.Instance.currentGameState == GameState.Playing)
        {
           
            Time.timeScale = 0;
            
            gameObject.SetActive(true);
            
            continuePlayingText.SetText("Continue Playing");


            String result = SUCCESS_MESSAGE;
            
            if (stars == 0)
            {
                burstAnimation.SetActive(false);
                result = FAIL_MESSAGE;
                
                continuePlayingText.SetText("Try Again");
                
                _globalUserData.SetInventoryValue("Life", 
                    _globalUserData.GetInventoryValue("Life") - 1);
            }

            resultMessage.SetText(result);

        
            for (int i = 0; i < stars; i++)
            {
                this.stars[i].SetActive(true);
            }


            for (int i = stars; i < 3; i++) // max 3 stars
            {
                this.stars[i].SetActive(false);
            }
            
            
            
            TD.Game.GameManager.Instance.currentGameState = GameState.Results;
        }
  

     

    }
    

    
    
}
