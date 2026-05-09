using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Manages scene loading for main menu, tutorial, game and quitting the game. 
public class SceneHandler : MonoBehaviour
{
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
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    public void GoToGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

}
