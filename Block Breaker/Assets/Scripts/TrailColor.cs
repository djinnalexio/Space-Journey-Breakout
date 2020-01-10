using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColor : MonoBehaviour
{
    [SerializeField] Color[] trailPhases;
    [Space(5)]
    [SerializeField] int[] comboIndexChange;
    [Space(5)]
    [SerializeField] float trailTimeIncrease = .2f;
    [SerializeField]
    [Tooltip("Percentage of the fraction of the increase")]
    [Range(0,1)]    
    float WidthIncrementPercent = .9f;

    int phaseCount;
    /*[SerializeField]*/
    int currentPhase;

    Color baseColor;
    float baseWidth;
    float baseTime;
    float trailWidthIncrease;

    TrailRenderer ballTrail;
    Level level;

    private void GetBaseParameters()
    {
        phaseCount = trailPhases.Length;

        baseColor = ballTrail.startColor;
        baseWidth = ballTrail.startWidth;
        baseTime = ballTrail.time;

        trailWidthIncrease = ((1 - baseWidth) / phaseCount) * WidthIncrementPercent;
    }

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        ballTrail = GetComponent<TrailRenderer>();
        GetBaseParameters();
    }

    
    // Update is called once per frame
    void Update()
    {
        UpdateTrailPhase();
    }


    private void UpdateTrailPhase()
    {
        currentPhase = 0;
        for (int i = 0; i < phaseCount; i++)
        { if (level.comboCount >= comboIndexChange[i]) currentPhase = i + 1; }

        if (currentPhase > 0)
        {
            ballTrail.startColor = trailPhases[currentPhase - 1];
            ballTrail.startWidth = baseWidth + trailWidthIncrease * currentPhase;
            ballTrail.time = baseTime + trailTimeIncrease * currentPhase;
        }

        else
        {
            ballTrail.startColor = baseColor;
            ballTrail.startWidth = baseWidth;
            ballTrail.time = baseTime;
        }
    }
}