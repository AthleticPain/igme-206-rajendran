using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that stores info about this gameobjects sprite renderer component and bounding circle
public class SpriteInfo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public float boundingCircleRadius;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Set bounding circle radius to be half of the diagonal of the sprite renderer's bounding box
        boundingCircleRadius = 0.5f * Mathf.Sqrt(spriteRenderer.bounds.size.x * spriteRenderer.bounds.size.x +
            spriteRenderer.bounds.size.y * spriteRenderer.bounds.size.y);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, boundingCircleRadius);
    }
}
