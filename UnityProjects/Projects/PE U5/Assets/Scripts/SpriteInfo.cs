using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Vector3 minBounds;
    public Vector3 maxBounds;

    private void Update()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
