using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that links all other ball scripts
/// </summary>

public class BallController : MonoBehaviour
{
    internal BallMovement movement;           // script for all movement functions and logic
    internal BallAudio sound;           // script for all audio logic
    
    [Header("External Scripts")]
    [SerializeField] internal PlayerController player;      // script to link to all player functions
    
    void Awake() 
    {
        movement = GetComponent<BallMovement>();
        sound = GetComponent<BallAudio>();
    }

}
