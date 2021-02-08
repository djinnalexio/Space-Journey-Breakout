using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeviation : MonoBehaviour
{
    
    [Header("Offset Parameters")]
    [Space(10)]
    [SerializeField] float DeviationValue = 10f;                               // multiplier used to control deviation from contact with paddle
    [SerializeField] PolygonCollider2D paddleCollider;                          // get collider to find in-world size of the paddle 
    float paddleLength;                                                           


    // AWAKE
    void Awake()
    {
        paddleLength = paddleCollider.bounds.size.x;                            // record the horizontal size of the paddle from the collider
    }



    // ONCOLLISION
    private void OnCollisionEnter2D(Collision2D ball)
    {
        DeviateBall(ball);
    }

    private void DeviateBall(Collision2D ball)
    {
        float contactPoint =                                                    // result is between -.5 and +.5 that corresponds to position on the paddle
        (ball.GetContact(0).point.x - transform.position.x) / paddleLength;     // (spot of the paddle the ball touched) / length of the paddle
        
        ball.rigidbody.velocity = 
        new Vector2(contactPoint * DeviationValue, ball.rigidbody.velocity.y);  // apply the new angle to the ball
    }
}
