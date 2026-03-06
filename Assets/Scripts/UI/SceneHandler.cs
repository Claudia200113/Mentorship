using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene(1);
    }
    
    public void GoToGame()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToGameOver()
    {
        SceneManager.LoadScene(3);
    }

}
