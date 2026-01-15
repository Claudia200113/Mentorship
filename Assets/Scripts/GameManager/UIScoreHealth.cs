using A2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace A2
{
    public class UIScoreHealth : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gemsText;
        [SerializeField] private Health health;
        private float currentScore = 1;

        public static UIScoreHealth Instance
        {
            get;
            private set;
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

        }
        private void Update()
        {
            GetHealth();
            GetScore();
            GetGems();
        }

        private void GetHealth()
        {
            healthText.text = "Health: " + health.currentHp.ToString();
        }

        private void GetScore()
        { 
            currentScore += 1 * Time.deltaTime;
            scoreText.text = "Score: " + (int)currentScore;
        }

        private void GetGems()
        {
            int numberGems = GameManager.Instance.playerInventory.numberGems;
            gemsText.text = "x " + numberGems;
        }

    }

}
