using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] int scoreValue = 10;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform fireSpawnpoint;
    [SerializeField] float fireRate = 0.5f;

    [SerializeField] float damageForceMagnitude = 10;

    [SerializeField] EnemyShipController shipController;

    [SerializeField] CustomCollider _collider;

    private void Awake()
    {
        if (!_collider)
        {
            _collider = GetComponent<CustomCollider>();
        }
    }

    private void OnEnable()
    {
        _collider.OnCollisionDetected += Collision;
    }

    private void OnDisable()
    {
        _collider.OnCollisionDetected -= Collision;
    }

    private void Start()
    {
        InvokeRepeating(nameof(FireProjectile), 2, fireRate);
    }

    void FireProjectile()
    {
        Instantiate(projectilePrefab, fireSpawnpoint.position, Quaternion.identity);
    }

    public void DealDamage(int damageValue, Vector3 damageDirection)
    {
        health -= damageValue;

        shipController.AddForceToShip(damageDirection * damageForceMagnitude);

        if(health <= 0)
        {
            Kill();
        }
    }
    private void Kill()
    {
        shipController.SpawnDestructionVFX();
        Destroy(gameObject);
    }

    void Collision(CustomCollider other)
    {
        if (other.collisionLayer == CustomCollisionLayer.PlayerShip)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();

            Debug.Log("Enemy Ship Collision!");

            DealDamage(1, -direction);
        }
    }

    private void OnDestroy()
    {
        ScoreController.Instance.AddToScore(scoreValue);
        EnemySpawner.Instance.DeregisterEnemy(this);
    }
}
