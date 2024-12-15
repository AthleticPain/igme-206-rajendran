using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeSpawner : MonoBehaviour
{
    [SerializeField] GameObject blackholePrefab;
    [SerializeField] float spawnDelay;
    [SerializeField] float spawnPositionX;

    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        InvokeRepeating(nameof(SpawnBlackhole), 10, spawnDelay);
    }

    void SpawnBlackhole()
    {

        Vector2 minBounds = mainCamera.ScreenToWorldPoint(Vector2.zero);
        Vector2 maxBounds = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, mainCamera.pixelHeight));

        float spawnPositionY = Random.Range(minBounds.y, maxBounds.y);

        Instantiate(blackholePrefab, new Vector2(spawnPositionX, spawnPositionY), Quaternion.identity);
    }
}
