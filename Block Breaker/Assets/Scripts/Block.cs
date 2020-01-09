using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that contains information about block and block behaviour
/// </summary>

public class Block : MonoBehaviour
{
    [SerializeField] bool breakable = true;
    [SerializeField] int blockPoints = 0;

    [Space(10)]
    [SerializeField] [Tooltip("Size of this array determines the number of hits")] Sprite[] blockPhases;
    
    [Header("SFX")]
    [Space(5)]
    [SerializeField] AudioClip blockBreakSFX;

    [Header("VFX")]
    [Space(5)]
    [SerializeField] GameObject blockBreakVFX;
    [SerializeField] float particlesTime = 1f;

    [Space(5)]
    [SerializeField] GameObject blockBreakFlash;
    [SerializeField] float flashTime = .1f;

    [Space(5)]
    [SerializeField] [Range(0.1f, .9f)] float maxColorReduction = .6f;

    Level level;
    GameSession game;
    CameraShake cameraShake;

    float baseHP;
    float currentHP;
    Color baseColor;

    void Start()
    {
        level = FindObjectOfType<Level>();
        game = FindObjectOfType<GameSession>();
        cameraShake = FindObjectOfType<CameraShake>();
        baseColor = GetComponent<SpriteRenderer>().color;

        if (breakable)
        {
            currentHP = baseHP = blockPhases.Length;
            level.AddBlock();
            CrackBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (breakable) { HandleHit(); }
    }

    private void HandleHit()
    {
        currentHP--;//lower HP
        level.ComboIncrease();
        if (currentHP <= 0) { DestroyBlock(); }
        else { CrackBlock(); DarkenBlock(); }
    }

    
    private void DestroyBlock()
    {
        if (blockBreakVFX != null)
        {
            GameObject VFX = Instantiate(blockBreakVFX, transform.position, Quaternion.identity);
            VFX.GetComponent<ParticleColor>().SetStartColor(baseColor);
            Destroy(VFX, particlesTime);
        }
        else Debug.LogError("Block Break VFX is missing: " + gameObject.name);
        
        if (blockBreakFlash != null)
        {
            GameObject flash = Instantiate(blockBreakFlash, transform.position, Quaternion.identity);
            Destroy(flash, flashTime);
        }
        else Debug.LogError("Block Break Flash is missing: " + gameObject.name);

        cameraShake.ShakeCamera();
        level.BlockDestroyed();
        game.AddToScore(blockPoints * level.comboCount);
        Destroy(gameObject);
        if (blockBreakSFX) { AudioSource.PlayClipAtPoint(blockBreakSFX, Camera.main.transform.position); }//play sound effect if it's there
    }


    private void CrackBlock()
    {
        int blockPhase = Mathf.RoundToInt(baseHP - currentHP);
        if (blockPhases[blockPhase] != null) GetComponent<SpriteRenderer>().sprite = blockPhases[blockPhase];
        else Debug.LogError("Block sprite is missing from array\nBlock: " + gameObject.name + "\nPhase: " + blockPhase);
    }


    private void DarkenBlock()
    {
        float currentColorReduction = 1 - maxColorReduction * ((baseHP - currentHP) / baseHP);
        GetComponent<SpriteRenderer>().color = new Vector4(//darken color at each hit
        baseColor.r * (currentColorReduction), //Red
        baseColor.g * (currentColorReduction), //Green
        baseColor.b * (currentColorReduction), //Blue
        1.000f);  //Transparent
    }
}
