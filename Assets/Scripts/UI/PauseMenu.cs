using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    public static bool GamePaused = false;

    void Start()
    {
        Time.timeScale = 1;
        GamePaused = false;
    }

    void Update()
    {
        HandlePause();
    }

    void HandlePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }

    private void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }

}
