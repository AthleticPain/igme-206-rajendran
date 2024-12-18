using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAsteroid : Projectile
{
    public Vector2 AsteroidDirection
    {
        set
        {
            projectileDirection = value;
        }
    }

    protected override void OnCustomCollision(CustomCollider other)
    {
        if (other.collisionLayer == CustomCollisionLayer.EnemyShip)
        {

            Enemy enemy = other.GetComponent<Enemy>();
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();

            enemy.DealDamage(damageValue, direction);

            Destroy(gameObject);
        }
    }
}
