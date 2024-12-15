using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    [SerializeField] CustomCollider _collider;
    [SerializeField] List<Ship> ships = new List<Ship>();
    [SerializeField] List<Projectile> projectiles = new List<Projectile>();
    [SerializeField] float gravitationalForce = 5;

    [SerializeField] Vector2 movementDirection = Vector2.left;
    [SerializeField] float movementSpeed = 1;

    List<Ship> shipsToRemove = new List<Ship>();
    List<Projectile> projectilesToRemove = new List<Projectile>();
    private void OnEnable()
    {
        _collider.OnCollisionDetected += Collision;
    }

    private void OnDisable()
    {
        _collider.OnCollisionDetected -= Collision;
    }

    void Collision(CustomCollider other)
    {
        if (other.collisionLayer == CustomCollisionLayer.PlayerShip || other.collisionLayer == CustomCollisionLayer.EnemyShip)
        {
            Ship shipToAdd = other.GetComponent<Ship>();

            if (ships.Contains(shipToAdd))
            {
                return;
            }

            ships.Add(shipToAdd);
        }
        else if (other.collisionLayer == CustomCollisionLayer.PlayerProjectile || other.collisionLayer == CustomCollisionLayer.EnemyProjectile)
        {
            Projectile projectileToAdd = other.GetComponent<Projectile>();

            if (projectiles.Contains(projectileToAdd))
            {
                return;
            }

            projectiles.Add(other.GetComponent<Projectile>());
        }
    }

    private void Update()
    {
        transform.position += (Vector3)movementDirection * movementSpeed * Time.deltaTime;

        ApplyGravityToNearbyObjects();

        if(transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    private void ApplyGravityToNearbyObjects()
    {
        shipsToRemove.Clear();
        projectilesToRemove.Clear();

        for (int i = 0; i < ships.Count; i++)
        {
            if (ships[i] == null)
            {
                shipsToRemove.Add(ships[i]);
                continue;
            }

            Vector2 direction = (transform.position - ships[i].transform.position);
            float distance = direction.sqrMagnitude;

            if (distance > _collider.colliderSize.sqrMagnitude)
            {
                shipsToRemove.Add(ships[i]);
                continue;
            }
            direction.Normalize();
            ships[i].AddForceToShip(direction * gravitationalForce);
        }

        foreach (Ship ship in shipsToRemove)
        {
            ships.Remove(ship);
        }


        for (int i = 0; i < projectiles.Count; i++)
        {
            if (projectiles[i] == null)
            {
                projectilesToRemove.Add(projectiles[i]);
                continue;
            }

            Vector2 direction = (transform.position - projectiles[i].transform.position);
            float distance = direction.sqrMagnitude;

            if (distance > _collider.colliderSize.sqrMagnitude)
            {
                projectilesToRemove.Add(projectiles[i]);
                continue;
            }

            direction.Normalize();
            projectiles[i].AddForceToProjectile(direction * gravitationalForce);
        }

        foreach (Projectile projectile in projectilesToRemove)
        {
            projectiles.Remove(projectile);
        }
    }
}
