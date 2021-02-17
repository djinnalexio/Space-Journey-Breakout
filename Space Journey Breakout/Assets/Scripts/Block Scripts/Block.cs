using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that contains information about block and block behaviour
/// </summary>

public class Block : MonoBehaviour
{
    [SerializeField] internal BlockData blockSettings;          // settings file

    // Components
    SpriteRenderer blockRenderer;

    // values that will change in runtime
    [SerializeField] int currentPhase = 0;           // how many hits block has taken
    [SerializeField] bool isBreakable;
    int totalPhases;           // number of hits block can take
    

    private void Awake()
    {
        blockRenderer = GetComponent<SpriteRenderer>();

        totalPhases = blockSettings.blockPhases.Length;         // get max HP from number of phases in settings
        isBreakable = blockSettings.breakable;          // get breakable or not
        blockRenderer.sprite = blockSettings.blockPhases[currentPhase];     // change to first phase
        blockRenderer.color = blockSettings.blockColor;         // change to color from settings
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }


    void HandleHit()    // when ball hits block
    {
        if (isBreakable)    // if block is breakable..
        {
            currentPhase++;     // add a hit point

            if (currentPhase == totalPhases)        // if max number of HP reached ... 
            {
                DestroyBlock();
            }

            else
            {
                CrackBlock();
            }
        }
    }

    void CrackBlock()
    {
        blockRenderer.sprite = blockSettings.blockPhases[currentPhase];     // change to corresponding phase
        AudioSource.PlayClipAtPoint(
            blockSettings.blockCrackSound,
            Camera.main.transform.position);        // play crack sound effect
    }

    void DestroyBlock()
    {
        Explode();          // events when destroying object
        gameObject.SetActive(false);        // disable object
    }

    void Explode()
    {
        // create flash of light from explosion and destroy after set time
        GameObject flash = Instantiate(blockSettings.blockBreakFlash, transform.position, Quaternion.identity);
            Destroy(flash, blockSettings.flashTime);

        // create rocks and dust from explosion
        GameObject blockDust =
            Instantiate(blockSettings.blockBreakVFX, transform.position, Quaternion.identity);
        
        ParticleSystem blockDustPS = blockDust.GetComponent<ParticleSystem>();// get ParticleSystem of the object
        var _ = blockDustPS.main;       // get the 'main' module
        _.startColor = blockSettings.blockColor;        // set color of particles
        Destroy(blockDust, blockSettings.particlesTime);        // destroy after set time

        // sound of explosion
        AudioSource.PlayClipAtPoint(blockSettings.blockBreakSound, Camera.main.transform.position);
    }
}
