using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to read and get all player inputs 
/// </summary>

public class PlayerInput : MonoBehaviour
{

    PlayerController controller;


    internal InputMaster controls;
    
    
    internal Vector2 movementInput = Vector2.zero;          // returns horizontal inputs from keys
    internal Vector2 mousePosition = Vector2.zero;          // returns the position of the mouse
    
    
    void Awake() 
    {
        controller = GetComponent<PlayerController>();
        controls = new InputMaster();           // initiate the input system
        
        // Pass value of key inputs to variable
        controls.Player.MovementKeys.performed += _ =>
            movementInput = _.ReadValue<Vector2>();

        // Pass position of mouse to variable and convert it to world units at the same time
        controls.Player.MovementMouse.performed += _ =>
            mousePosition = Camera.main.ScreenToWorldPoint(_.ReadValue<Vector2>());
    }

    // Enable Input system to make it work
    #region Enable/Disable
    void OnEnable() { controls.Enable(); }
    void OnDisable() { controls.Disable(); }
    #endregion

}
