using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CustomCollisionManager : MonoBehaviour
{
    public static CustomCollisionManager instance;

    public Transform playerShipTransform;
    [SerializeField] List<CustomCollider> allColliders = new List<CustomCollider>();
    [SerializeField] Vector2 worldBoundsMin;
    [SerializeField] Vector2 worldBoundsMax;
    [SerializeField] float boundsPadding = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        worldBoundsMin = Camera.main.ScreenToWorldPoint(Vector2.zero);
        worldBoundsMax = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
    }

    private void Update()
    {
        CheckBounds();
        CheckCollision();
    }

    public void RegisterNewCollider(CustomCollider newCollider)
    {
        allColliders.Add(newCollider);
    }

    public void DeregisterCollider(CustomCollider collider)
    {
        allColliders.Remove(collider);
    }

    void CheckCollision()
    {
        for (int i = 0; i < allColliders.Count - 1; i++)
        {
            for (int j = i + 1; j < allColliders.Count; j++)
            {
                if (allColliders[i].MaxBounds.x > allColliders[j].MinBounds.x && allColliders[i].MaxBounds.y > allColliders[j].MinBounds.y
                    && allColliders[i].MinBounds.x < allColliders[j].MaxBounds.x && allColliders[i].MinBounds.y < allColliders[j].MaxBounds.y)
                {
                    allColliders[i].CollisionDetected(allColliders[j]);
                    allColliders[j].CollisionDetected(allColliders[i]);
                }
            }
        }
    }

    void CheckBounds()
    {
        for (int i = 0; i < allColliders.Count; i++)
        {
            Vector2 position = (Vector2)allColliders[i].transform.position;
            if (position.x > worldBoundsMax.x + boundsPadding || position.x < worldBoundsMin.x - boundsPadding
                || position.y > worldBoundsMax.y + boundsPadding || position.y < worldBoundsMin.y - boundsPadding)
            {
                CustomCollider colliderToDestroy = allColliders[i];
                allColliders.RemoveAt(i);
                i--;
                Destroy(colliderToDestroy.gameObject);
            }
        }
    }
}
