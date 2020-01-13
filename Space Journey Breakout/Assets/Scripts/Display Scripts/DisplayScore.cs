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

    void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel.text = "Stage " + GameSession.levelCount.ToString();
        currentScore.text = GameSession.currentScore.ToString("D7");
        highScore.text = GameSession.highScore.ToString("D7");
        DisplayCombo();
    }

    void DisplayCombo()
    {
        if (level.GetCombo() >= 3)
        {
            comboHeading.SetActive(true);
            combo.text = "X" + level.GetCombo().ToString();
        }
        else
        {
            comboHeading.SetActive(false);
            combo.text = "";
        }
    }
}
