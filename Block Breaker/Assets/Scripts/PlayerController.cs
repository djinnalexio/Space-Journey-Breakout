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
    float contactOffset = 0f;

    Level level;
    GameSession gameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!level.pauseOn) { Move(); }
    }

    private void Move()
    {
        playerXPos = Mathf.Clamp( GetXPos(), 0 + playerRange, ScreenWidthUnits - playerRange);
        transform.position = new Vector2(playerXPos, transform.position.y);
    }

    private float GetXPos()
    {
        if (gameSession.GetAutoplay())
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
        contactOffset = collision.GetContact(0).point.x - transform.position.x;
        collision.rigidbody.velocity = new Vector2(contactOffset * offsetMultiplier, collision.rigidbody.velocity.y);
        /*Debug.Log("Sprite Width: " + gameObject.GetComponent<SpriteRenderer>().sprite.rect.width
            + "          Object Scale X: " + gameObject.transform.localScale.x
            + "\ncontact Offset: " + contactOffset
            );*/
    }
}
