using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private GameManager gameManager;

    void Awake()
    {
        
    }

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameManager = GameManager.Instance;
        UpdateScoreDisplay();
    }

    void Update()
    {
            UpdateScoreDisplay();
 
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + gameManager.score.ToString();
    }
}
