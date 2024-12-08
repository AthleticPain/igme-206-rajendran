using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float radius;
    [SerializeField] SpriteRenderer spriteRenderer;
    private void Awake()
    {
        if(!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        radius = spriteRenderer.bounds.size.x;
    }
}
