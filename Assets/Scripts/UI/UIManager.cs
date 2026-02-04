using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Text")] 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gemsText;

    [Header("Health")] 
    public Image heartImage;
    public Sprite fullHeart, halfHeart, threeQuartersHeart, quarterHeart, emptyHeart;
    

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
