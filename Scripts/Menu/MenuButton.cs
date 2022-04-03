using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{


    public GameObject target;
    public GameObject mainCanvas;


    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }
    
    private void OnButtonClick()
    {
        mainCanvas.SetActive(false);
        target.SetActive(true);
    }
    
}
