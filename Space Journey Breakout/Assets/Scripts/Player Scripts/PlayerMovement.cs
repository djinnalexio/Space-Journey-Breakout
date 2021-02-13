using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls all player movement
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    
    PlayerController controller;


    [SerializeField] internal float speed = 20f;            // movement speed when using key inputs
    [SerializeField] float ScreenWidthUnits;            // width of the screen in world units
    [SerializeField] float deadArea = 6.35f;            // Unaccessible screen area on either side
    [SerializeField] internal bool followCursorEnabled = true;     // whether mouse pointer is enabled
    

    
    void Awake() 
    {
        controller = GetComponent<PlayerController>();
        ScreenWidthUnits = Camera.main.transform.position.x * 2; // screen size = camera center position in world * 2
    }

    
    void FixedUpdate()
    {
            if (followCursorEnabled) { MoveWithMouse(); } // if using mouse, follow cursor
            else { MoveWithKeys(); }    // else, use keys to move
    }



    void MoveWithKeys()
    {
        // record last position for calculations
        float lastPosition = transform.position.x;
        
        // calculate how much player will move from key press
        float delta =  controller.input.movementInput.x * speed * Time.deltaTime;
        
        // constraint the new position by the dead area on either side
        float newPositionX = Mathf.Clamp(lastPosition + delta, 
            deadArea, ScreenWidthUnits - deadArea);
        
        // apply new position
        transform.position = new Vector2(newPositionX,transform.position.y);
    }

    void MoveWithMouse()
    {
        // X coordinate of the mouse limited by the dead area on either side
        float newPositionX = Mathf.Clamp(controller.input.mousePosition.x, 
            deadArea, ScreenWidthUnits - deadArea);

        // apply new position
        transform.position = new Vector2(newPositionX, transform.position.y);
    }

}
