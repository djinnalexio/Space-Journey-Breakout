using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that tracks information about the game session
/// </summary>

public class GameSession : MonoBehaviour
{
    //Score Variables
    public int GetCurrentScore() { return currentScore; }
    static int currentScore = 0;
    public int GetHighScore() { return highScore; }
    static int highScore = 0;
    public int GetPreviousHighScore() { return previousHighScore; }
    static int previousHighScore = 0;


    //Combo Variables
    public int GetHighCombo() { return highCombo; }
    static int highCombo = 0;
    public int GetPreviousHighCombo() { return previousHighCombo; }
    static int previousHighCombo = 0;


    //Stage Count Variables
    public int GetLevelCount() { return levelCount; }
    static int levelCount = 0;
    public int GetPreviousHighLevel() { return previouslevelCount; }
    static int previouslevelCount = 0;


    //Life Variables
    public int GetCurrentLives() { return lives; }
    static int lives = 0;
    [SerializeField] int baseLifeCount = 20;


    //Autoplay Variables
    public bool GetAutoplay() { return autoplayEnabled; }
    [SerializeField] bool autoplayEnabled = false;


    //other
    [SerializeField] public bool directStart = true;

    private void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLifeCount;
        if (directStart) levelCount = 1;
    }

    public void AddToScore(int points) 
    { 
        currentScore += points;
        if (currentScore > highScore) { highScore = currentScore; }
    }

    public void ResetGameSession() 
    { 
        previousHighScore = highScore;
        if (previousHighCombo < highCombo) previousHighCombo = highCombo;
        if (previouslevelCount < levelCount) previouslevelCount = levelCount;
        currentScore = 0;
        highCombo = 0;
        levelCount = 0;
        lives = baseLifeCount;
    }

    public void UpdateHighCombo(int combo) { if (combo > highCombo) { highCombo = combo; } }

    public void AddLevelPoint() { levelCount++; }

    public void LoseLife() { lives--; }
}
