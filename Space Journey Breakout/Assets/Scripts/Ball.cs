using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls the ball
/// </summary>

public class Ball : MonoBehaviour
{
    [Header("Launch Parameters")]
    [SerializeField] float ballSpeed = 5f;                                      //  The amount of units that the ball will move each second
    [SerializeField] Vector2 startingSpot = new Vector2(16f,5f);                // distance from the bottom or the screen the ball waits
    [SerializeField] bool lockedBall = true;                                    // is ball is currently locked in place
    Rigidbody2D ballRig;                                                        // Rigidbody2D; component of the ball
    

    [Header("Randomization")]
    [Space(10)]
    [SerializeField] float randomContactFactor = .2f;                           // force randomly applied at each collision to prevent back and forth loops


    [Header("SFX")]
    [Space(10)]
    [SerializeField] AudioClip ballHit;                                         // sound when ball hits an object
    AudioSource ballAudioSource;                                                // Audio source for sound effects
    

    // AWAKE
    void Awake()
    {
        ballRig = GetComponent<Rigidbody2D>();
        ballAudioSource = GetComponent<AudioSource>();
    }


    // START
    void Start()
    {
        resetBall();                                                            // place the ball in starting position
    }


    // UPDATE
    void Update()
    {
        if (lockedBall) { LaunchBall(); }                                       // if ball in starting position, click to launch
        if (Input.GetMouseButtonDown(1)) { resetBall(); }                       // click at any moment to reset ball
    }


    // FIXEDUPDATE
    void FixedUpdate() 
    {
        ballRig.velocity = ballSpeed * (ballRig.velocity.normalized);           // maintains ball speed. Physics are involved so part of FixedUpdate
    }


    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lockedBall = false;                                                 // mark ball as unlock
            ballRig.AddForce(Vector2.down);                                     // launch it towards the player
        }
    }

    public void resetBall()
    {
        lockedBall = true;                                                      // mark ball as unlock
        transform.position = startingSpot;                                      // set it back to starting position
        ballRig.velocity = Vector2.zero;                                        // set movement to zero
    }


    // ONCOLLISION
    private void OnCollisionEnter2D(Collision2D solidObject)
    {
        ballAudioSource.PlayOneShot(ballHit);                                   // play a sound when the ball touches an object

        TweakDirection();
    }

    private void TweakDirection()                                               // slightly change collision angle of the ball to prevent back and forth loops
    {
        Vector2 VelocityTweak = new Vector2(
                    Random.Range(0, randomContactFactor),                       // randomly assigns X and Y values
                    Random.Range(0, randomContactFactor));
        ballRig.AddForce(VelocityTweak);                                        // apply tweak
    }
}
