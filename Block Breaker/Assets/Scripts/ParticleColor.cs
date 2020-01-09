using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to change particle system start color
/// </summary>
/// 
public class ParticleColor : MonoBehaviour
{
    ParticleSystem ps;
    
    public void SetStartColor(Color color)
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = color;
    }
}
