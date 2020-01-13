using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The scripts that connects the buttons of the 'Settings' scene to the GameSession variables
/// </summary>

public class GameSettings : MonoBehaviour
{
    //Settings Interface
    [Header("Safety Net")]
    [SerializeField] Toggle safetyNetOn;

    [Header("Volume Settings")]
    [Space(10)]
    [SerializeField] Slider volumeLevel;

    [Header("Power Settings")]
    [Space(10)]
    [SerializeField] Toggle wreckingBallButton;
    [SerializeField] Toggle antiMatterButton;
    [SerializeField] Toggle partyTimeButton;
    
    void Start()
    {
        safetyNetOn.isOn = GameSession.safetyNetEnabled;

        volumeLevel.value = GameSession.volume;

        wreckingBallButton.isOn = GameSession.wreckingBallSet;
        antiMatterButton.isOn = GameSession.antiMatterSet;
        partyTimeButton.isOn = GameSession.partyTimeSet;
    }

    void Update()
    {
        GameSession.safetyNetEnabled = safetyNetOn.isOn;

        GameSession.volume = volumeLevel.value;

        GameSession.wreckingBallSet = wreckingBallButton.isOn;
        GameSession.antiMatterSet = antiMatterButton.isOn;
        GameSession.partyTimeSet = partyTimeButton.isOn;
    }

}

