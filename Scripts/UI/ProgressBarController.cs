using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
 

        slider.maxValue = 100;
    }

    public void SetProgress(float progress)
    {
        slider.value = progress;
    }

    public float GetProgress()
    {
        return slider.value;
    }
}
