using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRhythm : MonoBehaviour
{
    // Singleton instance
    private static GameManagerRhythm instance;

    // Public properties or variables for game state, score, etc.
    public int score = 0;
    public int combo = 0;
    public bool isGameOver = false;
    [SerializeField] private float speed;
    [SerializeField] private float BPM;
    [SerializeField] private int highscore;
    // Getter for the singleton instance
    public static GameManagerRhythm Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        highscore = PlayerPrefs.GetInt("HighscoreRhythmGame", 0);
    }

    private void Start()
    {
        BPM = 90;
        speed = 5f;
    }

    // Example method to increase the score
    public void IncreaseScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            // Additional score-related logic or event handling can be implemented here
        }
        if (score > highscore)
        {
            PlayerPrefs.SetInt("HighscoreRhythmGame", score);
            highscore = score;
        }
    }
    public void IncreaseCombo(int points)
    {
        if (!isGameOver)
        {
            combo += points;
        }
    }
    public void ResetCombo()
    {
        combo = 0;
    }

    // Example method to end the game
    public void GameOver()
    {
        isGameOver = true;
        // Perform actions when the game is over, such as displaying a game over screen, saving high scores, etc.
    }
    
    public float getBPM()
    {
        return BPM;
    }

    public float getSpeed()
    {
        return speed;
    }
}
