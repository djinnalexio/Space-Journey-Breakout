using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Script that displays the remaining amount of lives
/// </summary>

public class DisplayPowerCount : MonoBehaviour
{
    [SerializeField] GameObject powerIcon;
    [SerializeField] float powerIconSpacingY = 1f;

    List<PowerContainer> powerCount;
    
    void Start()
    {
        Vector2 basePos = powerIcon.transform.position;
        Vector2 Yshift = new Vector2(0, powerIconSpacingY);
        int position = 0;

        for (int remainingUses = GameSession.powerUses; remainingUses > 0; remainingUses--)
        {
            GameObject reservePower = Instantiate(powerIcon, basePos + (position * Yshift), Quaternion.identity);
            reservePower.GetComponent<PowerContainer>().containerIndex = position;
            position++;
        }

        powerCount = FindObjectsOfType<PowerContainer>().OrderBy(x => x.GetComponent<PowerContainer>().containerIndex).ToList();
    }

    public void RemoveAPowerUp() { Destroy(powerCount[powerCount.Count - 1].gameObject); powerCount.RemoveAt(powerCount.Count - 1); }
}
