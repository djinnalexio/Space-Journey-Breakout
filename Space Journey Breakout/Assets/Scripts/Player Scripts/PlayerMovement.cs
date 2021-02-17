using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls all player movement
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    
    PlayerController controller;

    float ScreenWidthUnits;            // width of the screen in world units
    
    
    void Awake() 
    {
        controller = GetComponent<PlayerController>();
        ScreenWidthUnits = Camera.main.transform.position.x * 2; // screen size = camera center position in world * 2
    }

    
    void FixedUpdate()
    {
            if (controller.playerSettings.followCursorEnabled)
            { MoveWithMouse(); } // if using mouse, follow cursor
            else { MoveWithKeys(); }    // else, use keys to move
    }



    void MoveWithKeys()
    {
        // record last position for calculations
        float lastPosition = transform.position.x;
        
        // calculate how much player will move from key press
        float delta =  controller.input.movementInput.x * controller.playerSettings.speed * Time.deltaTime;
        
        // constraint the new position by the dead area on either side
        float newPositionX = Mathf.Clamp(lastPosition + delta, 
            controller.playerSettings.deadArea, ScreenWidthUnits - controller.playerSettings.deadArea);
        
        // apply new position
        transform.position = new Vector2(newPositionX,transform.position.y);
    }

    void MoveWithMouse()
    {
        // X coordinate of the mouse limited by the dead area on either side
        float newPositionX = Mathf.Clamp(controller.input.mousePosition.x, 
            controller.playerSettings.deadArea, ScreenWidthUnits - controller.playerSettings.deadArea);

        // apply new position
        transform.position = new Vector2(newPositionX, transform.position.y);
    }

}
