using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Script that displays session information on the Game Over screen
/// </summary>

public class FinalDisplayScore : MonoBehaviour
{
    [Header("Score Headings")]
    [SerializeField] TextMeshProUGUI yourScoreHeading;
    [SerializeField] TextMeshProUGUI highScoreHeading;
    [Header("Score Text")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI yourScore;
    [SerializeField] TextMeshProUGUI highScore;

    [Header("Combo Headings")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI yourComboHeading;
    [SerializeField] TextMeshProUGUI highComboHeading;    
    [Header("Combo Text")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI yourCombo;
    [SerializeField] TextMeshProUGUI highestCombo;

    [Header("Level Headings")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI yourLevelHeading;
    [SerializeField] TextMeshProUGUI highLevelHeading;
    [Header("Level Text")]
    [Space(5)]
    [SerializeField] TextMeshProUGUI yourLevel;
    [SerializeField] TextMeshProUGUI highestLevel;

    GameSession gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        DisplaySessionScore();
        DisplaySessionCombo();
        DisplaySessionLevel();
    }
   

    private void DisplaySessionScore()
    {
        yourScore.text = gameStatus.GetCurrentScore().ToString("D7");
        highScore.text = gameStatus.GetPreviousHighScore().ToString("D7");

        if (gameStatus.GetCurrentScore() > gameStatus.GetPreviousHighScore())//beat highscore
        {
            yourScoreHeading.text = "New High Score";
            highScoreHeading.text = "Previous High Score";            
        }
        else
        {
            yourScoreHeading.text = "Your Score";
            highScoreHeading.text = "High Score";
        }
    }
    private void DisplaySessionCombo()
    {
        yourCombo.text = gameStatus.GetHighCombo().ToString();
        highestCombo.text = gameStatus.GetPreviousHighCombo().ToString();

        if (gameStatus.GetHighCombo() > gameStatus.GetPreviousHighCombo())//beat highscore
        {
            yourComboHeading.text = "New Combo Record";
            highComboHeading.text = "Previous Combo";
        }
        else
        {
            yourComboHeading.text = "Your Combo";
            highComboHeading.text = "Highest Combo";
        }
    }
    private void DisplaySessionLevel()
    {
        yourLevel.text = gameStatus.GetLevelCount().ToString();
        highestLevel.text = gameStatus.GetPreviousHighLevel().ToString();

        if (gameStatus.GetLevelCount() > gameStatus.GetPreviousHighLevel())//beat level
        {
            yourLevelHeading.text = "New Level Reached";
            highLevelHeading.text = "Previous Record";
        }
        else
        {
            yourLevelHeading.text = "Level Reached";
            highLevelHeading.text = "Record";
        }
    }
}
