using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float radius;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Adjusted to account for consistent 2D behavior
        radius = spriteRenderer.bounds.extents.x;
    }
}
