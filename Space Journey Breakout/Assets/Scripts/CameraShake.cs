using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that shakes the camera
/// </summary>

public class CameraShake : MonoBehaviour
{
    [SerializeField] float duration = .15f;
    [SerializeField] float magnitude = .4f;
    
    Vector3 originalPos;

    void Start() { originalPos = transform.localPosition; }

    public void ShakeCamera() { StartCoroutine(Shake()); }
    IEnumerator Shake ()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float xShake = Random.Range(-1f, 1f) * magnitude;
            float yShake = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(
                originalPos.x + xShake,
                originalPos.y + yShake, 
                originalPos.z);
            elapsedTime += Time.deltaTime;
            yield return Time.deltaTime;
        }
        transform.localPosition = originalPos;
    }
}
