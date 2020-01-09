using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that displays the remaining amount of lives
/// </summary>

public class DisplayLifeCount : MonoBehaviour
{
    [SerializeField] GameObject spareLife;
    [SerializeField] float lifeBarSpacingY = .5f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] bool counterClockWise = false;
    float direction = 1;

    GameObject[] lifeReserve;

    GameSession gameSession;

    void Awake() { gameSession = FindObjectOfType<GameSession>(); }

    void Start()
    {
        int position = 0;
        for (int lifeLeft = gameSession.GetCurrentLives() - 1; lifeLeft > 0; lifeLeft--)
        {
            Vector2 basePos = spareLife.transform.position;
            Vector2 Yshift = new Vector2(0, lifeBarSpacingY);
            GameObject reserveLife = Instantiate(spareLife, basePos + (position * Yshift), Quaternion.identity);
            position++;
        }
        lifeReserve = GameObject.FindGameObjectsWithTag("SpareLife");
    }

    void Update()
    {
        if (counterClockWise) { direction = rotationSpeed; }
        else { direction = -rotationSpeed; }

        foreach (GameObject reserveLife in lifeReserve)
        {
            reserveLife.transform.Rotate(new Vector3(0, 0, direction) * Time.deltaTime);
        }
    }
}
