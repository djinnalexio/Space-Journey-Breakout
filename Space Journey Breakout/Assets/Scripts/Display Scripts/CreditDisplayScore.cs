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

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = GameSession.previousHighScore.ToString("D7");
        highestCombo.text = GameSession.previousHighCombo.ToString();
        highestLevel.text = GameSession.previouslevelCount.ToString();
    }
}
