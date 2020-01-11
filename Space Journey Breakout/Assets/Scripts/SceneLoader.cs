using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script used to move between scenes
/// </summary>

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float gameOverDelay = 2f;
    [SerializeField] float retryDelay = 1f;
    [SerializeField] float NextLevelDelay = 1.5f;

    GameSession gameSession;
    Level level;
    DisplayLifeCount displayLife;
    Ball ball;

    private void Awake() 
    {
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        displayLife = FindObjectOfType<DisplayLifeCount>();
        ball = FindObjectOfType<Ball>();
    }


    //Main Menu Functions
    public void AppQuit() { Application.Quit(); }
    public void LoadCredits() { SceneManager.LoadScene("Credits"); }
    public void LoadInstructions() { SceneManager.LoadScene("Instructions"); }
    public void LoadOptions() { SceneManager.LoadScene("Options"); }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
        gameSession.ResetGameSession();
    }


    //Game Functions
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        gameSession.AddLevelPoint();
    }
    
    
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        gameSession.ResetGameSession();
        gameSession.AddLevelPoint();
    }


    public void NextLevel()
    {
        level.LostLife(false);
        StartCoroutine(DelayedTransition("Game", NextLevelDelay, true));
    }


    public void NextLife()
    {
        if (gameSession.GetCurrentLives() <= 0) { StartCoroutine(DelayedTransition("Game Over", gameOverDelay, false)); }

        else if (gameSession.resetStageModeEnabled)
        {
            level.LostLife(true);
            StartCoroutine(DelayedTransition("Game", retryDelay, false));
        }

        else { StartCoroutine(ReloadBall()); }
    }

    IEnumerator DelayedTransition(string scene, float delay, bool movingToNextLevel)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
        if (movingToNextLevel) gameSession.AddLevelPoint();
    }

    IEnumerator ReloadBall()
    {
        yield return new WaitForSeconds(retryDelay);
        displayLife.RemoveAContainer();
        ball.SetBallLockedStatus(true);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
