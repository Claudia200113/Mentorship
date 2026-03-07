using UnityEditor;
using UnityEngine;

namespace UI
{
    public class UIUpdator : MonoBehaviour
    {
        private float score;
        public bool GamePaused = false;

        void Start()
        {
            Time.timeScale = 1;
            GamePaused = false;
        }

        private void Update()
        {
            SetScore();
            SetGems();
            UpdateHearts();
            HandlePause();

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


    }
}

