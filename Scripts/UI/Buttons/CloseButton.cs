using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    // Start is called before the first frame update

    private Button button;
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClick);
    }


    private void OnButtonClick()
    {
        transform.parent.gameObject.SetActive(false);

    }
   
}
