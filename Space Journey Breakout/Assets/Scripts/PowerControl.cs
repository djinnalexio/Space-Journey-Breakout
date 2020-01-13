using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that contains data about the powerups, behaviours
/// </summary>

public class PowerControl : MonoBehaviour
{
    [Header("General Settings")]
    public bool powerOn = false;
    [SerializeField] [Range(0f, 20f)] float powerDuration = 5f;
    [SerializeField] [Range(0f, 1f)] public float powerBonusPercent = .25f;

    [Header("Wrecking Ball")]
    [Space(5)]
    [SerializeField] [Range(0, 5)] float sizeMultiplier = 2;
    [SerializeField] float speedMultiplier = .8f;
    public bool wreckingBallOn = false;

    [Header("Anti-Matter")]
    [Space(5)]
    [SerializeField] Sprite antiMatterBall;
    [SerializeField] [Range(0f, 5f)] public float blockMeltingRate = .6f;
    [SerializeField] [Range(0f, 1f)] public float blockErasePoint = .2f;
    public bool antiMatterOn = false;

    [Header("Party Time")]
    [Space(5)]
    [SerializeField] int extraBalls = 2;
    [SerializeField] float launchAngleOffset = 5f;
    [SerializeField] public float ballSpeedIncrease = .4f;
    public bool partyTimeOn = false;


    DisplayPowerCount displayPower;
    Ball ball;
    TrailColor ballTrail;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        ballTrail = ball.GetComponentInChildren<TrailColor>();
        displayPower = FindObjectOfType<DisplayPowerCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSession.powerUses > 0 && !ball.lockedBall && powerOn == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                powerOn = true;
                GameSession.powerUses--;
                displayPower.RemoveAPowerUp();
                if (GameSession.wreckingBallSet) { StartCoroutine(ActivateWreckingBall()); }
                else if (GameSession.antiMatterSet) { StartCoroutine(ActivateAntiMatter()); }
                else if (GameSession.partyTimeSet) { StartCoroutine(ActivatePartyTime()); }
            }
        }
    }


    IEnumerator ActivateWreckingBall()
    {
        wreckingBallOn = true;
        ball.transform.localScale *= sizeMultiplier;
        ball.ballSpeed *= speedMultiplier;
        ballTrail.baseWidth *= sizeMultiplier;

        yield return new WaitForSeconds(powerDuration);

        ball.transform.localScale /= sizeMultiplier;
        ball.ballSpeed /= speedMultiplier;
        ballTrail.baseWidth /= sizeMultiplier;
        wreckingBallOn = false;
        powerOn = false;
    }


    IEnumerator ActivateAntiMatter()
    {
        if (antiMatterBall != null)
        {
            Sprite baseSprite = ball.GetComponent<SpriteRenderer>().sprite;
            ball.GetComponent<SpriteRenderer>().sprite = antiMatterBall;
            antiMatterOn = true;

            yield return new WaitForSeconds(powerDuration);

            ball.GetComponent<SpriteRenderer>().sprite = baseSprite;
            antiMatterOn = false;
            powerOn = false;
        }

        else
        {
            ball.GetComponent<SpriteRenderer>().color = Color.gray;
            antiMatterOn = true;

            yield return new WaitForSeconds(powerDuration);

            ball.GetComponent<SpriteRenderer>().color = Color.white;
            antiMatterOn = false;
            powerOn = false;
        }        
    }

    
    IEnumerator ActivatePartyTime()
    {
        partyTimeOn = true;
        ball.ballSpeed *= (1 + ballSpeedIncrease);
        for (int newBallIndex = 1; newBallIndex <= extraBalls; newBallIndex++)
        {
            GameObject extraBall = Instantiate(ball.gameObject, ball.transform.position, Quaternion.identity);
            Vector2 trajectoryTweak = new Vector2(
                UnityEngine.Random.Range(-launchAngleOffset, launchAngleOffset),
                UnityEngine.Random.Range(-launchAngleOffset, launchAngleOffset));
            extraBall.GetComponent<Rigidbody2D>().AddForce(trajectoryTweak);
        }

        yield return new WaitUntil(()=> partyTimeOn == false);

        ball = FindObjectOfType<Ball>();
        ballTrail = ball.GetComponentInChildren<TrailColor>();
        ball.ballSpeed /= (1 + ballSpeedIncrease);
        powerOn = false;
    }
}
