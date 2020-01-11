using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that scrolls the background
/// </summary>

public class BGScroller : MonoBehaviour
{
    [SerializeField] float defaultScrollingSpeed = .5f;
    public float scrollingSpeed;
    Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        scrollingSpeed = defaultScrollingSpeed;
    }

    // Update is called once per frame
    void Update() { myMaterial.mainTextureOffset += new Vector2(0, scrollingSpeed) * Time.deltaTime; }
}
