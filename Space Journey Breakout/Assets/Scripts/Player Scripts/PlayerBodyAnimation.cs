using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that affects the animation if the player body
/// </summary>

public class PlayerBodyAnimation : MonoBehaviour
{
    PlayerController controller;
 
    [SerializeField] Animator bodyAnimator;                 // Animator for the base of the player
    [SerializeField] float sensitivity = 1;                 //sensitivity to speed
    bool movingToTheRight = true;                           // Direction of the paddle
    float playerXDelta = 0f;                                // Speed of the player
    float lastPlayerXPosition = 0f;                         // position on the previous frame to calculate speed
    
    void Awake() 
    {
        controller = GetComponent<PlayerController>();
    }
        
    // UPDATE
    void Update()
    {
        AnimateDirection();
    }


    private void AnimateDirection()
    {
        // get the speed (how much the body moved since the last frame)
        playerXDelta = transform.position.x - lastPlayerXPosition;

        // record the position to compare it to the next frame
        lastPlayerXPosition = transform.position.x;

        // set the animator parameter to recorded speed and add multiplier
        bodyAnimator.SetFloat("Speed", Mathf.Abs(playerXDelta * sensitivity * 100f));
        
        if (
            (playerXDelta > 0 && !movingToTheRight) // if the player is moving to the right but the body is facing left...
            ||                                      // or
            (playerXDelta < 0 && movingToTheRight)  // if the player is moving to the left but the body is facing right...
        )
        { Flip(); }                                 // ... flip the player.

    }

    private void Flip()
    {
        movingToTheRight = !movingToTheRight;       // Switch the way the player is labelled as facing.

		Vector3 theScale = transform.localScale;
        
        theScale.x *= -1;                           // Multiply the player's x local scale by -1 to flip the object
		transform.localScale = theScale;
    }
}
