using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] internal float speed = 20f;
    [SerializeField] float ScreenWidthUnits;
    [SerializeField] float deadArea = 6.35f;                                       // Unaccessible screen area on either side
    [SerializeField] internal bool followCursorEnabled = true;
    



    PlayerController controller;
    
    void Awake() 
    {
        controller = GetComponent<PlayerController>();
        ScreenWidthUnits = Camera.main.transform.position.x * 2;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (followCursorEnabled) { moveWithMouse(); }
            else { moveWithKeys(); }
    }



    void moveWithKeys()
    {
        float lastPosition = transform.position.x;
        
        float delta =  controller.input.movementInput.x * speed * Time.deltaTime;
        
        float newPositionX = Mathf.Clamp(lastPosition + delta, 
            deadArea, ScreenWidthUnits - deadArea);
        
        transform.position = new Vector2(newPositionX,transform.position.y);
    }

    void moveWithMouse()
    {
        float newPositionX = Mathf.Clamp(controller.input.mousePosition.x, 
            deadArea, ScreenWidthUnits - deadArea);

        transform.position = new Vector2(newPositionX, transform.position.y);
    }

}
