using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that contains information about block and block behaviour
/// </summary>

public class Block : MonoBehaviour
{
    [SerializeField] internal BlockData settings;

    // Components
    SpriteRenderer blockRenderer;

    // values that will change in runtime
    [SerializeField] int currentPhase = 0;
    [SerializeField] int totalPhases;
    [SerializeField] bool isBreakable;


    private void Awake()
    {
        blockRenderer = GetComponent<SpriteRenderer>();

        totalPhases = settings.blockPhases.Length;
        isBreakable = settings.breakable;
        blockRenderer.sprite = settings.blockPhases[currentPhase];
        blockRenderer.color = settings.blockColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();


        //blockAudio.PlayOneShot(settings.blockBreakSound);
        //gameObject.SetActive(false);
    }


    void HandleHit()
    {
        if (isBreakable)
        {
            currentPhase++;

            if (currentPhase == totalPhases)
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
        blockRenderer.sprite = settings.blockPhases[currentPhase];
        AudioSource.PlayClipAtPoint(settings.blockCrackSound, Camera.main.transform.position);
    }

    void DestroyBlock()
    {
        Explode();
        Destroy(gameObject);
    }

    void Explode()
    {
        // Flash of light from explosion
        GameObject flash = Instantiate(settings.blockBreakFlash, transform.position, Quaternion.identity);
            Destroy(flash, settings.flashTime);

        // rocks and dust from explosion
        GameObject blockDust =
            Instantiate(settings.blockBreakVFX, transform.position, Quaternion.identity);
        
        ParticleSystem blockDustPS = blockDust.GetComponent<ParticleSystem>();
        var _ = blockDustPS.main;
        _.startColor = settings.blockColor;
        Destroy(blockDust, settings.particlesTime);

        // sound of explosion
        AudioSource.PlayClipAtPoint(settings.blockCrackSound, Camera.main.transform.position);
    }
}
