using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script for all active player logic (key press events)
/// </summary>

public class PlayerAction : MonoBehaviour
{
    PlayerController controller;

    void Awake() 
    {
        controller = GetComponent<PlayerController>();

        // Add launching the ball to actions triggered by "Shoot" input
        controller.input.controls.Player.Shoot.performed += _ => controller.ball.movement.LaunchBall();

        // Add pausing the game to actions triggered by "Pause" input
        controller.input.controls.Player.Pause.performed += _ => PauseGame();
        
        //TODO disable before building finished game | Link input "ResetBall" to resetting the ball
        controller.input.controls.Player.ResetBall.performed += _ => controller.ball.movement.ResetBall();
    }




    void PauseGame()
    {
        
    }
    
}
