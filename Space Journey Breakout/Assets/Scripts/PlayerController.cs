using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls Player movements
/// </summary>



public class PlayerController : MonoBehaviour
{

    //[Header("Player Components & Info")]

    [Header("Player Size Parameters")]
    [Space(10)]
    [SerializeField] float screenWidthUnits = 32f;                              // # of X units to calculate X position
    [SerializeField] float deadArea = 4f;                                       // Unaccessible screen area on either side

    
    private float playerXPos;                                                   // Current position of the player 
    private float mouseXPos;                                                    // Current position of the mouse
    


    // START
    void Start()
    {
        
        
    }

    
    // UPDATE
    void Update()
    {
        GetMouseXPosition();
    }


    // FIXEDUPDATE
    void FixedUpdate()
    {
        Move();
    }


    private void Move() 
    {
        transform.position =                                                    // player follows cursor
        new Vector2(playerXPos, transform.position.y);
    }

    private void GetMouseXPosition()                                            // Get the horizontal position of the mouse, divide by screen width
    {                                                                           // to get proportion of mouse position by screen width
        mouseXPos = Input.mousePosition.x / Screen.width * screenWidthUnits;    // then multiply by world units to have real in-world position

        playerXPos = Mathf.Clamp(mouseXPos,                                     // Position of the player is limited to position of the mouse within the bounds
        deadArea, screenWidthUnits - deadArea);
    }

    
}
