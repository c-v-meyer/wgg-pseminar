using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    private static GameManager instance;

    // Public properties or variables for game state, score, etc.
    public int score = 0;
    public bool isGameOver = false;

    // Getter for the singleton instance
    public static GameManager Instance
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
    }

    

    // Example method to increase the score
    public void IncreaseScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            // Additional score-related logic or event handling can be implemented here
        }
    }

    // Example method to end the game
    public void GameOver()
    {
        isGameOver = true;
        // Perform actions when the game is over, such as displaying a game over screen, saving high scores, etc.
    }
}
