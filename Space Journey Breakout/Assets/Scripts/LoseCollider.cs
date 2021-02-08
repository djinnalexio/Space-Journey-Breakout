using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script that controls what happens when an object touches the bottom collider
/// </summary>

public class LoseCollider : MonoBehaviour
{
    

    // ONTRIGGER
    private void OnTriggerEnter2D(Collider2D fallen_ball)
    {
        //SceneManager.LoadScene(4);
    }
    
}
