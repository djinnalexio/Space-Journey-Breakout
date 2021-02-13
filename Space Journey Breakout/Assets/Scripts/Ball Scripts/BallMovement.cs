using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls ball movement logic
/// </summary>

public class BallMovement : MonoBehaviour
{

    BallController controller;

    [Header("Movement Parameters")]
    [SerializeField] internal float ballSpeed = 5f;                             //  The amount of units that the ball will move each second
    [SerializeField] Vector2 startingSpot = new Vector2(16f,5f);                // distance from the bottom or the screen the ball waits
    [SerializeField] internal bool lockedBall = false;                          // is ball is currently locked in place
    [SerializeField] float randomContactFactor = .2f;                           // force randomly applied at each collision to prevent back and forth loops
    Rigidbody2D ballRig;                                                        // Rigidbody2D; component of the ball
    

    void Awake()
    {
        controller = GetComponent<BallController>();
        ballRig = GetComponent<Rigidbody2D>();
    }
        

    // Start is called before the first frame update
    void Start()
    {
        ResetBall(); // setup ball position at start
    }

    // FIXEDUPDATE
    void FixedUpdate() 
    {
        ballRig.velocity = ballSpeed * (ballRig.velocity.normalized);           // maintains ball speed. Physics are involved so part of FixedUpdate
    }



    internal void LaunchBall()
    {
        if (lockedBall)
        {
            lockedBall = false;                                                 // mark ball as unlock
            ballRig.AddForce(Vector2.down);                                     // launch it towards the player
        }
    }

    internal void ResetBall()
    {
        if (!lockedBall)
        {
            lockedBall = true;                                                      // mark ball as unlock
            transform.position = startingSpot;                                      // set it back to starting position
            ballRig.velocity = Vector2.zero;                                        // set movement to zero
        }
        
    }

        // ONCOLLISION
    void OnCollisionEnter2D(Collision2D solidObject)
    {
        TweakDirection();
    }

    void TweakDirection()  // slightly change collision angle of the ball to prevent back and forth loops
    {
        Vector2 VelocityTweak = new Vector2(
                    Random.Range(0, randomContactFactor),                       // randomly assigns X and Y values
                    Random.Range(0, randomContactFactor));
        ballRig.AddForce(VelocityTweak);                                        // apply tweak
    }
}
