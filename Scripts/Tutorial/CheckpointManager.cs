using System;
using System.Collections;
using System.Collections.Generic;
using TD.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
   private Button _button;

   private TutorialManager _tutorialManager;


   private void Start()
   {
      _button = GetComponent<Button>();
      _tutorialManager = TutorialManager.Instance;
      
      _button.onClick.AddListener(OnNextCheckPoint);
   }


   private void OnNextCheckPoint()
   {
      

      if (_tutorialManager.CheckPointCount != _tutorialManager.TCheckPoints.Length - 1)
      {
         _tutorialManager.CheckPointCount++;
         
         
         _tutorialManager.TCheckPoints[_tutorialManager.CheckPointCount].SetActive(true);
         _tutorialManager.TCheckPoints[_tutorialManager.CheckPointCount - 1].SetActive(false);
      }
      else
      {
         ResultManager.instance.HandleResults(3);
      }
   }
}
