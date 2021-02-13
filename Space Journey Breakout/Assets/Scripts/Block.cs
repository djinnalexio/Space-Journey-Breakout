using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that contains information about block and block behaviour
/// </summary>

public class Block : MonoBehaviour
{
    [Header("Block Sprites")]    
    [SerializeField] Sprite solidBlock;
    [SerializeField] Sprite[] blockStates;
    SpriteRenderer blockRenderer;
    
    
    [Header("SFX")]
    [Space(10)]
    [SerializeField] AudioClip blockBreakSound;
    AudioSource blockAudio;

    private void Awake()
    {
        blockRenderer = GetComponent<SpriteRenderer>();
        blockAudio = GetComponent<AudioSource>();
        blockRenderer.sprite = solidBlock;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        blockAudio.PlayOneShot(blockBreakSound);
        gameObject.SetActive(false);
    }

}
