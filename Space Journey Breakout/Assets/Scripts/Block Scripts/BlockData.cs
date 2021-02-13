using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template that contains value for types of blocks
/// </summary>

[CreateAssetMenu(fileName = "BlockFile", menuName = "BlockFile")]

public class BlockData : ScriptableObject
{
    [Header("Block Information")]
    public bool breakable = true;    // if block can be broken
    public int blockPoints = 0;  // points awarded when block is hit

    [Space(10)]
    [Tooltip("number of sprites = number of hits block can take")]
    public Sprite[] blockPhases; // # of phases = # of hit points

    [Space(10)]
    public Color blockColor; // color for that type of block
}
