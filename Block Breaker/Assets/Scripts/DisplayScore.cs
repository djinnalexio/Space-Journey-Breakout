using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Script that displays game information in the game scene:
///  - Score
///  - High Score
///  - Combo
///  - Current Stage
/// </summary>

public class DisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI combo;
    [SerializeField] GameObject comboHeading;
    [SerializeField] TextMeshProUGUI currentLevel;

    GameSession gameStatus;
    Level level;

    void Awake()
    {
        gameStatus = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel.text = "Stage " + gameStatus.GetLevelCount().ToString();
        currentScore.text = gameStatus.GetCurrentScore().ToString("D7");
        highScore.text = gameStatus.GetHighScore().ToString("D7");
        DisplayCombo();
    }

    void DisplayCombo()
    {
        if (level.comboCount > 2)
        {
            comboHeading.SetActive(true);
            combo.text = "X" + level.comboCount.ToString();
        }
        else
        {
            comboHeading.SetActive(false);
            combo.text = "";
        }
    }
}
