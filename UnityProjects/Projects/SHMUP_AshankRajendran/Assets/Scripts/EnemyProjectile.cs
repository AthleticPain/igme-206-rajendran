using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    protected override void OnCustomCollision(CustomCollider other)
    {
        if (other == null)
            return;

        if (other.collisionLayer == CustomCollisionLayer.PlayerShip)
        {

            PlayerHealth player = other.GetComponent<PlayerHealth>();
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();

            player.DealDamage(damageValue, direction);

            Destroy(gameObject);
        }
        else if (other.collisionLayer == CustomCollisionLayer.PlayerProjectile)
        {
            Destroy(gameObject);
        }
    }
}
