using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Calculates the score and saves high score when game finishes.
public class ScoreManager : MonoBehaviour
{
   [HideInInspector] public float currentScore;
   [HideInInspector] public float finalScore;
   public void Update()
   {
      currentScore += Time.deltaTime;
   }
   public void SetHighScore()
   {
      //Final score is calculated by base score and amount of gems collected.
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
}
