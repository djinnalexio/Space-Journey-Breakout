using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Script that controls Player movements
/// </summary>

//TODO separate player script into function animation, input, move

//TODO keep game logic out of UI

//TODO try to use scriptable objects instead of permanent gameobject from scene to scene
public class PlayerController : MonoBehaviour
{
    

    internal PlayerInput input;
    internal PlayerMovement movement;
    internal PlayerAction action;
    [SerializeField] internal ballMovement ballMove;
    
    void Awake() 
    {
        input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        action = GetComponent<PlayerAction>();
    }



    



    
}
