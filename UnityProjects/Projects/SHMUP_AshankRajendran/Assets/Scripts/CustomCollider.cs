using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class CustomCollider : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] public CustomCollisionLayer collisionLayer;

    [SerializeField] bool useCustomColliderSize;
    public Vector2 colliderSize;

    CustomCollisionManager customCollisionManager;

    public delegate void CollisionEventHandler(CustomCollider other);

    public event CollisionEventHandler OnCollisionDetected;

    public Vector2 MinBounds
    {
        get
        {
            return spriteRenderer.bounds.min;
        }
    }

    public Vector2 MaxBounds
    {
        get
        {
            return spriteRenderer.bounds.max;
        }
    }

    private void Start()
    {
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (!useCustomColliderSize)
        {
            colliderSize = spriteRenderer.bounds.size;
        }

        customCollisionManager = CustomCollisionManager.instance;
        if(customCollisionManager!=null)
        {
            customCollisionManager.RegisterNewCollider(this);
        }
    }

    private void OnDestroy()
    {
        if (customCollisionManager != null)
        {
            customCollisionManager.DeregisterCollider(this);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 position = transform.position;

        Vector3 topLeft = position + new Vector3(-colliderSize.x / 2, colliderSize.y / 2, 0);
        Vector3 topRight = position + new Vector3(colliderSize.x / 2, colliderSize.y / 2, 0);
        Vector3 bottomLeft = position + new Vector3(-colliderSize.x / 2, -colliderSize.y / 2, 0);
        Vector3 bottomRight = position + new Vector3(colliderSize.x / 2, -colliderSize.y / 2, 0);


        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }

    public void CollisionDetected(CustomCollider other)
    {
        OnCollisionDetected?.Invoke(other);
    }
}

