using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that controls Player movements
/// </summary>

public class PlayerController : MonoBehaviour
{
    [Header("Player Size Parameters")]
    [SerializeField] float ScreenWidthUnits = 0f;
    [SerializeField] float playerRange = 0f;

    [Header("Offset Parameters")]
    [Space(10)]
    [SerializeField] float offsetMultiplier = 3f;
    [SerializeField] float autoplayRandomOffset = 1.5f;

    float playerXPos;
    public Vector2 GetplayerToBallVector() { return playerToBallVector; }
    Vector2 playerToBallVector;

    Level level;
    GameSession gameSession;
    Ball ball;
    PowerControl powerControl;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        playerToBallVector = ball.transform.position - transform.position;
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
        powerControl = FindObjectOfType<PowerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ball) ball = FindObjectOfType<Ball>();

        if (!level.isPaused) { Move(); }

        if(powerControl.powerOn) gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        else gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    private void Move()
    {
        playerXPos = Mathf.Clamp( GetXPos(), 0 + playerRange, ScreenWidthUnits - playerRange);
        transform.position = new Vector2(playerXPos, transform.position.y);
    }

    private float GetXPos()
    {
        if (gameSession.autoplayEnabled)
        {

            return Random.Range(
                ball.transform.position.x - autoplayRandomOffset,
                ball.transform.position.x + autoplayRandomOffset);
        }
        else { return Input.mousePosition.x / Screen.width * ScreenWidthUnits; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        level.ComboReset();
        DeviateBall(collision);
    }

    private void DeviateBall(Collision2D collision)
    {
        float contactOffset = collision.GetContact(0).point.x - transform.position.x;
        collision.rigidbody.velocity = new Vector2(contactOffset * offsetMultiplier, collision.rigidbody.velocity.y);
    }
}
