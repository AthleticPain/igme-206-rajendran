using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Projectile
{
    [SerializeField] int asteroidHP = 20;

    [SerializeField] int numberOfChildrenToSpawn = 10;
    [SerializeField] List<GameObject> childAsteroidPrefebs;

    public int HP
    {
        get 
        {
            return asteroidHP;
        }
        set
        {
            asteroidHP = value;

            if(asteroidHP <= 0)
            {
                Debug.Log("Asteroid Destroyed");
                AsteroidDestroy();
            }
        }
    }

    protected override void OnCustomCollision(CustomCollider other)
    {
        if (other.collisionLayer == CustomCollisionLayer.PlayerProjectile)
        {
            HP--;
        }
        else if (other.collisionLayer == CustomCollisionLayer.PlayerShip)
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();

            player.DealDamage(damageValue, direction);

            Destroy(gameObject);
        }
    }

    void AsteroidDestroy()
    {
        for (int i = 0; i < numberOfChildrenToSpawn; i++)
        {
            GameObject prefabToSpawn = childAsteroidPrefebs[Random.Range(0, childAsteroidPrefebs.Count)];


            float randomSpawnAngle = Random.Range(-45, 45) * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(randomSpawnAngle), Mathf.Sin(randomSpawnAngle));

            MiniAsteroid newAsteroid = Instantiate(prefabToSpawn, transform.position, Quaternion.identity).GetComponent<MiniAsteroid>();
            newAsteroid.AsteroidDirection = direction;
        }

        Destroy(gameObject);
    }
}
