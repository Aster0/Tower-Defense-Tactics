using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(this.transform.position, Vector2.up, (20 * Time.deltaTime) * 2);
    }
}
