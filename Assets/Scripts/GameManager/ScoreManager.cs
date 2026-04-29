using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   [HideInInspector] public float currentScore;
   [HideInInspector] public float finalScore;
   void OnEnable()
   {
      Health.OnPlayerDeath += GameOver; 
   }
   
   void OnDisable()
   {
      Health.OnPlayerDeath -= GameOver;
   }
   public void Update()
   {
      currentScore += Time.deltaTime;
   }
   private void GameOver()
   {
      finalScore = currentScore + (10 * GameManager.Instance.playerInventory.numberGems);
      
      if (PlayerPrefs.HasKey("SavedHighScore"))
      {
         if (finalScore > PlayerPrefs.GetInt("SavedHighScore"))
         {
            PlayerPrefs.SetInt("SavedHighScore",(int)finalScore);
         }
        
      } else
      {
         PlayerPrefs.SetInt("SavedHighScore", (int)finalScore);
      }
   }

   public void HighScoreUpdate()
   {
   
   }
}
