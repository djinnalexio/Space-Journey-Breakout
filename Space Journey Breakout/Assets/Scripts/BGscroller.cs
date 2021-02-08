using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script that scrolls the background of textured objects
/// </summary>


public class BGscroller : MonoBehaviour
{
    [SerializeField] float defaultScrollingSpeed = 1f;                          // default speed throughout game
    public float scrollingSpeed;                                                // speed affected by over elements
    Material myMaterial;                                                        // texture to scroll


    // AWAKE
    void Awake()
    {
        myMaterial = GetComponent<Renderer>().material;
        scrollingSpeed = defaultScrollingSpeed;                                 // Set starting scrolling speed
    }


    // FIXEDUPDATE
    void FixedUpdate()
    {
        myMaterial.mainTextureOffset += 
        new Vector2(0, -scrollingSpeed) * Time.deltaTime * .01f;                // Scrolling down while matching time and applying multiplier
    }
}
