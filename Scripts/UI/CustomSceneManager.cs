using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TD.Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CustomSceneManager : MonoBehaviour
{
    

    [SerializeField] private Slider slider;

    private bool animate = false;
    private CanvasGroup _canvasGroup;

    [SerializeField] private TextMeshProUGUI tipsText, loadingText;


    [SerializeField] private string[] loadingTips, loadingMessages;


    public static CustomSceneManager instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
        
          
            DontDestroyOnLoad(this.gameObject);

            instance = this;
            
            gameObject.SetActive(false);

            _canvasGroup = GetComponent<CanvasGroup>();
            slider.maxValue = 1;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string scenePath, bool preLoadScene)
    {


        Time.timeScale = 1;
        _canvasGroup.alpha = 0;
       
        gameObject.SetActive(true);
        

        slider.value = 0;
       
        tipsText.SetText("\"" + loadingTips[Random.Range(0, loadingTips.Length)] + "\"");


        if (preLoadScene)
        {
            AsyncOperation preScene = SceneManager.LoadSceneAsync("Scenes/TD/td_pre_load", LoadSceneMode.Single);

            while (preScene.progress < 0.9f) { }

            preScene.allowSceneActivation = true;
        }
       
        AsyncOperation scene = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);



        scene.allowSceneActivation = false;

        while (scene.progress < 0.9f)
        {
            
            await Task.Delay(100);
           


            
            
        
            slider.value = scene.progress;
            
            
        }
        
        foreach (string message in loadingMessages)
        {
            loadingText.SetText(message);
                
            await Task.Delay(50);
        }
        
        

        
        scene.allowSceneActivation = true;
        
      

        await Task.Delay(2000);
        
  

        animate = true;
   
  
    }
    
    

    private void Update()
    {
        
        if (animate)
        {
            _canvasGroup.alpha -= Time.deltaTime * 5;

            if (_canvasGroup.alpha <= 0)
            {
                gameObject.SetActive(false);
                animate = false;
            }


        }
        else
        {
            if (_canvasGroup.alpha != 1)
            {
                _canvasGroup.alpha += Time.deltaTime * 5;
            }
        }
        
    }
}
