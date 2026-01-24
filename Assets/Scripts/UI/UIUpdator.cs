using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdator : MonoBehaviour
{
    private float score;
    private void Update()
    {
        SetScore();
        SetGems();
    }

    private void SetScore()
    {
        score+= 1 * Time.deltaTime;
        UIManager.Instance.scoreText.text = "Score: " + (int)score;
    }

    private void SetGems()
    {
        var referenceToGems = GameManager.Instance.playerInventory.numberGems;
        UIManager.Instance.gemsText.text = "x " + referenceToGems;
    }
    
    
    
    
}

