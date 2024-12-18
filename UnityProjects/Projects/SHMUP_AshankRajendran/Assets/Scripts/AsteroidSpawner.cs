using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] float spawnDelay;
    [SerializeField] float spawnPositionX;

    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        InvokeRepeating(nameof(SpawnAsteroid), 5, spawnDelay);
    }

    void SpawnAsteroid()
    {

        Vector2 minBounds = mainCamera.ScreenToWorldPoint(Vector2.zero);
        Vector2 maxBounds = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, mainCamera.pixelHeight));

        float spawnPositionY = Random.Range(minBounds.y, maxBounds.y);

        Instantiate(asteroidPrefab, new Vector2(spawnPositionX, spawnPositionY), Quaternion.identity);
    }
}
