using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script that links all other player scripts
/// </summary>


//TODO keep game logic out of UI

//TODO try to use scriptable objects instead of permanent gameobject from scene to scene
public class PlayerController : MonoBehaviour
{
    [SerializeField] internal PlayerData playerSettings;        // object containing all player settings

    [Header("External Pieces")]
    [SerializeField] internal BallController ball;            // script to link to all ball functions
    [SerializeField] internal Animator bodyAnimator;                 // Animator for the base of the player
    




    internal PlayerInput input;         // script to read inputs 
    internal PlayerMovement movement;           // script for all movement functions and logic
    internal PlayerAction action;           // script for all active player logic (key press events)
    internal PlayerPaddle paddle;           // script for all paddle physics
    internal PlayerBodyAnimation bodyAnim;           // script for body animation

    
    void Awake() 
    {
        input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        action = GetComponent<PlayerAction>();
        paddle = GetComponent<PlayerPaddle>();
        bodyAnim = GetComponent<PlayerBodyAnimation>();
    }
    
}
