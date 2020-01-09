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
    GameSession gameSession;

    private void Start() 
    { 
        sceneLoader = FindObjectOfType<SceneLoader>(); 
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (level.breakableBlocks > 0)
        {
            gameSession.LoseLife();
            level.ComboReset();
            sceneLoader.NextLife();
        }        
    }
}
