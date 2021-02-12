using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls the animations of the player body
/// </summary>

public class BodyAnimation : MonoBehaviour
{
    
    private Animator bodyAnimator;                                              // Animator for the base of the player
    [SerializeField] bool movingToTheRight = true;                              // Direction of the paddle
    [SerializeField] float playerXDelta = 0f;                                   // Speed of the player
    float lastPlayerXPosition = 0f;                                             // position on the previous frame to calculate speed
    
    
    // AWAKE   
    void Awake()
    {
        bodyAnimator = GetComponent<Animator>();
    }

    
    // UPDATE
    void Update()
    {
        AnimateDirection();
    }


    private void AnimateDirection()
    {
        playerXDelta = transform.position.x - lastPlayerXPosition;              // get the speed (how much the body moved since the last frame)

        lastPlayerXPosition = transform.position.x;                             // record the position to compare it to the next frame

        bodyAnimator.SetFloat("Speed", Mathf.Abs(playerXDelta * 100f));         // set the animator parameter to recorded speed and add multiplier

        if (
            (playerXDelta > 0 && !movingToTheRight)                             // if the player is moving to the right but the body is facing left...
            ||                                                                  // or
            (playerXDelta < 0 && movingToTheRight)                              // if the player is moving to the left but the body is facing right...
        )
        { Flip(); }                                                             // ... flip the player.

    }

    private void Flip()
    {
        movingToTheRight = !movingToTheRight;                                   // Switch the way the player is labelled as facing.

		Vector3 theScale = transform.localScale;
        
        theScale.x *= -1;                                                       // Multiply the player's x local scale by -1 to flip the object
		transform.localScale = theScale;
    }
}
