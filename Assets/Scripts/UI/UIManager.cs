using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Singleton type, used to set all the references so other scripts can access them. No logic is managed here.
namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI Text")] 
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI gemsText;
        public TextMeshProUGUI gameOverText;
        public TextMeshProUGUI hiScoreText;
        
        [Header("Hearts Sprites")]
        public Sprite emptyHeart;
        public Sprite fullHeart;
        public Image[] hearts;

        [Header("UI Menus")]
        public GameObject pauseMenu;
        public GameObject gameOverMenu;
        public GameObject gameUI;

        public static UIManager Instance
        {
            get;
            set;
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
    }
}
