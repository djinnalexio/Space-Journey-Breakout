using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    PlayerController controller;

    //TODO rework input system for player movement input and make mouse work with it


    internal InputMaster controls;
    
    
    internal Vector2 movementInput = Vector2.zero;
    internal Vector2 mousePosition = Vector2.zero;
    
    
    void Awake() 
    {
        controller = GetComponent<PlayerController>();
        controls = new InputMaster();
        
        // Convert movement inputs from screen position to in-world units
        controls.Player.MovementKeys.performed += _ => movementInput = _.ReadValue<Vector2>();
        controls.Player.MovementMouse.performed += _ => mousePosition = Camera.main.ScreenToWorldPoint(_.ReadValue<Vector2>());
    }

    #region Enable/Disable
    void OnEnable() { controls.Enable(); }
    void OnDisable() { controls.Disable(); }
    #endregion

}
