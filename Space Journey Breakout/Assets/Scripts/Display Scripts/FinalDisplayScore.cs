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

    // Start is called before the first frame update
    void Start()
    {
        DisplaySessionScore();
        DisplaySessionCombo();
        DisplaySessionLevel();
    }
   

    private void DisplaySessionScore()
    {
        yourScore.text = GameSession.currentScore.ToString("D7");
        highScore.text = GameSession.previousHighScore.ToString("D7");

        if (GameSession.currentScore > GameSession.previousHighScore)//beat highscore
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
        yourCombo.text = GameSession.highCombo.ToString();
        highestCombo.text = GameSession.previousHighCombo.ToString();

        if (GameSession.highCombo > GameSession.previousHighCombo)//beat highscore
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
        yourLevel.text = GameSession.levelCount.ToString();
        highestLevel.text = GameSession.previouslevelCount.ToString();

        if (GameSession.levelCount > GameSession.previouslevelCount)//beat level
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
