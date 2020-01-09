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

    private void Awake() 
    {
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
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

    public void NextLevel()
    {
        level.SetLostLifeFalse();
        StartCoroutine(DelayedTransition("Game", NextLevelDelay, true));
    }

    public void NextLife()
    {
        if (gameSession.GetCurrentLives() <= 0 ) {
            StartCoroutine(DelayedTransition("Game Over", gameOverDelay, false));
        }
        else {
            level.SetLostLifeTrue();
            StartCoroutine(DelayedTransition("Game", retryDelay, false));
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        gameSession.ResetGameSession();
        gameSession.AddLevelPoint();
    }

    IEnumerator DelayedTransition(string scene,float delay, bool movingToNextLevel) 
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
        if (movingToNextLevel) gameSession.AddLevelPoint();
    }
}
