using UnityEngine;

//Subscribed to OnPlayerDeath event.
//Updates UI elements: score, gems, health, and pause and game over screens.
namespace UI
{
    public class UIUpdator : MonoBehaviour
    {
        public bool GamePaused = false;

        void OnEnable()
        {
            Health.OnPlayerDeath += GameOver; 
        }

        void OnDisable()
        {
            Health.OnPlayerDeath -= GameOver;
        }

        void Start()
        {
            Time.timeScale = 1;
            GamePaused = false;
        }

        private void Update()
        {
            ShowScore();
            ShowGems();
            UpdateHearts();
            HandlePause();
        }

        private void ShowScore()
        {
            UIManager.Instance.scoreText.text = "Score: " + (int)GameManager.Instance.scoreManager.currentScore;
        }

        private void ShowGems()
        {
            var referenceToGems = GameManager.Instance.playerInventory.numberGems;
            UIManager.Instance.gemsText.text = "x " + referenceToGems;
        }

        private void UpdateHearts()
        {
            var manager = UIManager.Instance;
            float currentHealth = (GameManager.Instance.playerHealth.currentHp / 20);
            
            for (int i = 0; i < UIManager.Instance.hearts.Length; i++)
            {
                if (i < currentHealth)
                {
                    manager.hearts[i].sprite = manager.fullHeart;
                }
                else
                {
                    manager.hearts[i].sprite = manager.emptyHeart;
                }
            }
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
            UIManager.Instance.pauseMenu.SetActive(false);
            Time.timeScale = 1;
            GamePaused = false;
        }

        private void Pause()
        {
            UIManager.Instance.pauseMenu.SetActive(true);
            Time.timeScale = 0;
            GamePaused = true;
        }

        void GameOver()
        {
            //Checks the highest saved score and updates if necessary
            GameManager.Instance.scoreManager.SetHighScore();
            UIManager.Instance.gameUI.SetActive(false); 
            //Shows game over screen
            UIManager.Instance.gameOverMenu.SetActive(true); 
            //Shows in UI the score and saved record
            UIManager.Instance.gameOverText.text = "Score: " + (int)GameManager.Instance.scoreManager.currentScore + " Gems: " + GameManager.Instance.playerInventory.numberGems + "\nFinal Score: " + (int)GameManager.Instance.scoreManager.finalScore; 
            UIManager.Instance.hiScoreText.text = "Record: " + PlayerPrefs.GetInt("SavedHighScore");
        }
    }
}

