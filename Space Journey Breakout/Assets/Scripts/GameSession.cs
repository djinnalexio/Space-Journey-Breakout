using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that tracks information about the game session
/// </summary>

public class GameSession : MonoBehaviour
{
    //Score Variables
    [SerializeField] public int PointsPerContact = 5;
    public static int currentScore = 0;
    public static int highScore = 0;
    public static int previousHighScore = 0;


    //Combo Variables
    public static int highCombo = 0;
    public static int previousHighCombo = 0;


    //Stage Count Variables
    public static int levelCount = 0;
    public static int previouslevelCount = 0;

    //Life Variables
    [SerializeField] int baseLifeCount = 5;
    public static int lives;

    //Autoplay Variables
    [SerializeField] public bool autoplayEnabled = false;
    [SerializeField] public bool directStart = true;

    //Lose Behaviour Variables
    public static bool safetyNetEnabled = true;
    [SerializeField] [Range(0f, 1f)] float noNetBonusPercent = .1f;

    //Volume Variables
    public static float volume = 1;

    //Power-Up Variables
    [SerializeField] int basePowerUses = 5;
    public static int powerUses;
    public static bool wreckingBallSet = true;
    public static bool antiMatterSet = false;
    public static bool partyTimeSet = false;

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
        powerUses = basePowerUses;
        if (directStart) levelCount = 1;
    }

    public void AddToScore(int points) 
    {
        if (!safetyNetEnabled) points += Mathf.RoundToInt(points * noNetBonusPercent);
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
        powerUses = basePowerUses;
    }

    public void UpdateHighCombo(int combo) { if (combo > highCombo) { highCombo = combo; } }

    public void AddLevelPoint() { levelCount++; }
}
