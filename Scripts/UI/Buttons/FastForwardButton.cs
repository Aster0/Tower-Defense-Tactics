using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForwardButton : MonoBehaviour
{

    private Button button;

    public Image icon;

    private Image buttonImage;


    public StartWaveButton startWaveButton;

    public bool pressed { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {


        if(!startWaveButton.resume)
        {
            if (!pressed)
            {
                Time.timeScale = 2;


                SetButtonColor(1);


            }
            else
            {
                Time.timeScale = 1;
                SetButtonColor(0.5f);
            }

            pressed = !pressed;
        }
        
        
    }


    public void SetButtonColor(float alpha)
    {
        Color tempColor = buttonImage.color;
        tempColor.a = alpha;

        buttonImage.color = tempColor;

        icon.color = tempColor;
    }

   
}
