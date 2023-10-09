using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    [SerializeField]private TextMeshProUGUI highscoreText;
    private GameManagerRhythm gameManager;

    void Awake()
    {
        
    }

    void Start()
    {
        //scoreText = GetComponent<TextMeshProUGUI>();
        gameManager = GameManagerRhythm.Instance;
        UpdateScoreDisplay();
    }

    void Update()
    {
            UpdateScoreDisplay();
 
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + gameManager.score.ToString();
        comboText.text = "Combo: " + gameManager.combo.ToString();
        highscoreText.text = "Highscoere: " + PlayerPrefs.GetInt("HighscoreRhythmGame");
    }
}
