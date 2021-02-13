using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls ball sounds
/// </summary>

public class BallAudio : MonoBehaviour
{

    BallController controller;

    [Header("SFX")]
    [Space(10)]
    [SerializeField] AudioClip ballHit;                                         // sound when ball hits an object
    AudioSource ballAudio;                                                      // Audio source for sound effects
    


    void Awake()
    {
        controller = GetComponent<BallController>();
        ballAudio = GetComponent<AudioSource>();
    }

// ONCOLLISION
    private void OnCollisionEnter2D(Collision2D solidObject)
    {
        ballAudio.PlayOneShot(ballHit);                     // play a sound when the ball touches an object
    }
}
