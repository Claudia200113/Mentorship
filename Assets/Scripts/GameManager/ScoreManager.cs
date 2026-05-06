using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   [HideInInspector] public float currentScore;
   [HideInInspector] public float finalScore;
   public void Update()
   {
      currentScore += Time.deltaTime;
   }
   public bool SetHighScore()
   {
      Debug.Log("SetHighScore Called");
      finalScore = currentScore + (10 * GameManager.Instance.playerInventory.numberGems);
      
      if (PlayerPrefs.HasKey("SavedHighScore"))
      {
         if (finalScore > PlayerPrefs.GetInt("SavedHighScore"))
         {
            PlayerPrefs.SetInt("SavedHighScore",(int)finalScore);
            return true;
         }
        
      } else
      {
         PlayerPrefs.SetInt("SavedHighScore", (int)finalScore);
         return true;
      }

      return false;
   }
}
