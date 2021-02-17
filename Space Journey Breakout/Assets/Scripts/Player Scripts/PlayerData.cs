using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// object containing all player settings
/// </summary>

[CreateAssetMenu(fileName = "Player Settings", menuName = "PlayerSettings")]

public class PlayerData : ScriptableObject
{
    [Header("Player Movement")]
    [Space(10)]
    [SerializeField] internal bool followCursorEnabled = true;     // whether mouse pointer is enabled
    [SerializeField] internal float speed = 25f;            // movement speed when using key inputs
    [SerializeField] internal float deadArea = 6.35f;            // Unaccessible screen area on either side


    [Header("Deviation Settings")]
    [Space(10)]
    [SerializeField] internal float DeviationValue = 25f;               // multiplier used to control deviation from contact with paddle
    
    
    [Header("Animation Settings")]
    [Space(10)]
    [SerializeField] internal float sensitivity = .4f;                 //sensitivity to speed
    
}
