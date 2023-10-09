using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPaperStack : MonoBehaviour
{

    public GameManagerPaperStack GameOverCanvas;
    public GameManagerPaperStack StartCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        StartCanvas.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetActive(bool value)
    {
        // ???
    }
}
