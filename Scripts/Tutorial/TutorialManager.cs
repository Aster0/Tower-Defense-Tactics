using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{


    [SerializeField] private GameObject checkPointParent;
    private GameObject[] mTCheckPoints;
    public GameObject[] TCheckPoints
    {
        get { return mTCheckPoints; }
    }


    private int _mCheckPointCount;
    
    
    public int CheckPointCount
    {
        get { return _mCheckPointCount;  }
        set { _mCheckPointCount = value;  }
    }
    
    
    public static TutorialManager Instance { get; set; }
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {

        mTCheckPoints = new GameObject[checkPointParent.transform.childCount];


        int count = 0;
        foreach (Transform child in checkPointParent.transform)
        {
            mTCheckPoints[count] = child.gameObject;
            
            if(count != 0)
                child.gameObject.SetActive(false);
            
            count++;
            

        }
        
   
        
        System.Array.Sort(mTCheckPoints, (x, y) => string.Compare(x.name, y.name));
        
        Debug.Log("Loaded " + mTCheckPoints.Length + " tutorial check points.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
