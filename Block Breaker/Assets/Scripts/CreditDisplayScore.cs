using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Script that displays session info on the credits page
/// </summary>

public class CreditDisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI highestCombo;
    [SerializeField] TextMeshProUGUI highestLevel;

    GameSession gameStatus;

    void Awake() { gameStatus = FindObjectOfType<GameSession>(); }

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = gameStatus.GetPreviousHighScore().ToString("D7");
        highestCombo.text = gameStatus.GetPreviousHighCombo().ToString();
        highestLevel.text = gameStatus.GetPreviousHighLevel().ToString();
    }
}
