using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    List<BallContainer> lifeReserve;
    float direction = 1;
    
    GameSession gameSession;    

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        Vector2 basePos = spareLife.transform.position;
        Vector2 Yshift = new Vector2(0, lifeBarSpacingY);
        int position = 0;

        for (int lifeLeft = gameSession.GetCurrentLives() - 1; lifeLeft > 0; lifeLeft--)
        {
            GameObject reserveLife = Instantiate(spareLife, basePos + (position * Yshift), Quaternion.identity);
            reserveLife.GetComponent<BallContainer>().containerIndex = position;
            position++;
        }

        lifeReserve = FindObjectsOfType<BallContainer>().OrderBy(x => x.GetComponent<BallContainer>().containerIndex).ToList();
    }

    void Update()
    {
        if (counterClockWise) { direction = rotationSpeed; }
        else { direction = -rotationSpeed; }

        foreach (BallContainer reserveLife in lifeReserve) { reserveLife.transform.Rotate(new Vector3(0, 0, direction) * Time.deltaTime); }
    }

    public void RemoveAContainer() { Destroy(lifeReserve[lifeReserve.Count - 1].gameObject); lifeReserve.RemoveAt(lifeReserve.Count - 1); }
}
