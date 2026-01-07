using A2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace A2
{
    public class UIScoreHealth : MonoBehaviour
    {
        //Textbox for health to be shown
        [SerializeField] private TextMeshProUGUI healthText;
        //Textbox for score to be shown
        [SerializeField] private TextMeshProUGUI scoreText;
        //GO with death message
        [SerializeField] private GameObject playerDead;
        [SerializeField] private Health health;
        private float currentScore = 1;

        public static UIScoreHealth Instance
        {
            get;
            private set;
        }

        //Sets the script to be a singleton.
        private void Awake()
        {
            //If script is instanced it will destroy it 
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
            PlayerDied();
        }

        private void GetHealth()
        {
            healthText.text = "Health: " + health.currentHP.ToString();
        }

        private void GetScore()
        {
            //If player is valid, the score continuously goes up
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                currentScore += 1 * Time.deltaTime;
            }
            scoreText.text = "Score: " + (int)currentScore;
        }
        

        private void PlayerDied()
        {
            if (health.currentHP <= 0)
            {
                playerDead.SetActive(true);
            }
        }

    }

}
