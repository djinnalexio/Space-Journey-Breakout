using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template that contains value for types of blocks
/// </summary>

[CreateAssetMenu(fileName = "_block", menuName = "Block Config")]

public class BlockData : ScriptableObject
{
    [Header("Block Settings")]
    [SerializeField] internal bool breakable = true;            // if block can be broken

    [Space(5)]
    [Tooltip("number of sprites = number of hits block can take")]
    [SerializeField] internal Sprite[] blockPhases;             // # of phases = # of hit points

    [Space(5)]
    [SerializeField] internal Color blockColor;                 // color for that type of block

    [Header("Block SFX")]
    [Space(10)]
    [SerializeField] internal AudioClip blockBreakSound;        // sound when block breaks
    [SerializeField] internal AudioClip blockCrackSound;        // sound when block only cracks

    [Header("Block VFX")]
    [Space(10)]
    [SerializeField] internal GameObject blockBreakVFX;         // particle system for broken block dust
    [SerializeField] internal float particlesTime = 1f;         // time effect lingers
    [SerializeField] internal GameObject blockBreakFlash;       // flash when block breaks
    [SerializeField] internal float flashTime = .1f;            // time flash lasts
    
}
