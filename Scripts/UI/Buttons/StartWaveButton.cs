using System.Collections;
using System.Collections.Generic;
using TD.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartWaveButton : MonoBehaviour
{

    private Button button;

    public FastForwardButton fastForwardButton;

    public Sprite[] iconSprites;
    public Image mIcon;
    public TextMeshProUGUI mText;

    public bool resume { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {


        if (!TD.Game.GameManager.Instance.WaveManager.started)
        {
            TD.Game.GameManager.Instance.WaveManager.OnWaveStart();

            SetInformationStart(0, "Pause Wave", 1);
         
        }
        else if(resume)
        {
            resume = false;
            SetInformationStart(0, "Pause Wave", 1);
        }

        else
        {
          
            SetInformationStart(1, "Start Wave", 0);
            resume = true;


        }
    }

    public void SetInformationStart(int icon, string text, int timeScale)
    {
        
        fastForwardButton.SetButtonColor(0.5f);
        fastForwardButton.pressed = false;
        
        mText.SetText(text);
        mIcon.sprite = iconSprites[icon];
        Time.timeScale = timeScale;
    }

  
}
