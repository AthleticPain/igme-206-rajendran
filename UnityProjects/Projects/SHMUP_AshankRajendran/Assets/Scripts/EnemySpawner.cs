using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [SerializeField] int maxNumberOfEnemies = 10;
    [SerializeField] float spawnRate = 2;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] List<EnemyMovementPath> enemyMovementPaths;

    [SerializeField] List<Enemy> activeEnemies;
    [SerializeField] List<Transform> enemySpawnPoints;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnRate);
    }

    public void RegisterNewEnemy(Enemy enemy)
    {
        activeEnemies.Add(enemy);
    }

    public void DeregisterEnemy(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
    }

    void SpawnEnemy()
    {
        if(activeEnemies.Count < maxNumberOfEnemies)
        {
            Vector3 spawnPosition = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)].position;
            EnemyMovementPath enemyMovementPath = enemyMovementPaths[Random.Range(0, enemyMovementPaths.Count)];

            Enemy newEnemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation).GetComponent<Enemy>();
            RegisterNewEnemy(newEnemy);

            newEnemy.GetComponent<EnemyShipController>().SetEnemyMovementPath(enemyMovementPath);
        }
    }

}
