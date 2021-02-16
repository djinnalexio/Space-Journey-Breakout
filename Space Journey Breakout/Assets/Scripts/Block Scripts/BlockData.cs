using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template that contains value for types of blocks
/// </summary>

[CreateAssetMenu(fileName = "BlockFile", menuName = "BlockFile")]

public class BlockData : ScriptableObject
{
    [Header("Block Settings")]
    public bool breakable = true;    // if block can be broken
    public int blockPoints = 0;  // points awarded when block is hit

    [Space(5)]
    [Tooltip("number of sprites = number of hits block can take")]
    public Sprite[] blockPhases; // # of phases = # of hit points

    [Space(5)]
    public Color blockColor; // color for that type of block

    [Header("Block SFX")]
    [Space(10)]
    [SerializeField] AudioClip blockBreakSFX;
    [SerializeField] AudioClip blockAnnihilateSFX;

    [Header("Block VFX")]
    [Space(10)]
    [SerializeField] GameObject blockBreakVFX;
    [SerializeField] float particlesTime = 1f;

    [Space(5)]
    [SerializeField] GameObject blockBreakFlash;
    [SerializeField] float flashTime = .1f;
    
}
