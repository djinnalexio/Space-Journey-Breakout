using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls what happens when an object touches the bottom collider
/// </summary>

public class LoseCollider : MonoBehaviour
{
    SceneLoader sceneLoader;
    Level level;
    PowerControl powerControl;

    private void Start() 
    { 
        sceneLoader = FindObjectOfType<SceneLoader>(); 
        level = FindObjectOfType<Level>();
        powerControl = FindObjectOfType<PowerControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (powerControl.partyTimeOn) { EraseExtraBall(collision); }
        else TriggerLoss();
    }

    private void EraseExtraBall(Collider2D collision)
    {
        int ballcount = FindObjectsOfType<Ball>().Length;
        Destroy(collision.GetComponent<Ball>());
        ballcount--;
        if (ballcount <= 1) { powerControl.partyTimeOn = false; }
        Destroy(collision.gameObject, 0.5f);      
    }

    private void TriggerLoss()
    {
        GameSession.lives--;
        level.ComboReset();
        sceneLoader.NextLife(FindObjectOfType<Ball>());
    }
}
