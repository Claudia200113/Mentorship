using UnityEngine;

namespace UI
{
    public class UIUpdator : MonoBehaviour
    {
        private float score;

        private void Update()
        {
            SetScore();
            SetGems();
            UpdateHearts();
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
    
    
    }
}

