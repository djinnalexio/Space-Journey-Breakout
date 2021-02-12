using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{

    PlayerController controller;
    [SerializeField] Ball ball;


    void Awake() 
    {
        controller = GetComponent<PlayerController>();

        controller.input.controls.Player.LoadLeftPower.performed += _ => ball.LaunchBall(); // add functions from ball to buttons
        controller.input.controls.Player.LoadRightPower.performed += _ => ball.resetBall();
    }


}
