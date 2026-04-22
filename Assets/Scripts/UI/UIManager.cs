using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI Text")] 
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI gemsText;
        public TextMeshProUGUI gameOverText;
        
        [Header("Hearts Sprites")]
        public Sprite emptyHeart;
        public Sprite fullHeart;
        public Image[] hearts;

        [Header("UI Menus")]
        public GameObject pauseMenu;
        public GameObject gameOverMenu;

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
