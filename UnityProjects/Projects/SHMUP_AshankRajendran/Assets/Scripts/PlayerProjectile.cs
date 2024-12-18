using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    protected override void OnCustomCollision(CustomCollider other)
    {
        if (other == null)
            return;

        if(other.collisionLayer == CustomCollisionLayer.EnemyShip)
        {
            
            Enemy enemy = other.GetComponent<Enemy>();
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();
            
            enemy.DealDamage(damageValue, direction);
            
            Destroy(gameObject);
        }
        else if(other.collisionLayer == CustomCollisionLayer.EnemyProjectile || other.collisionLayer == CustomCollisionLayer.Asteroid)
        {
            Destroy(gameObject);
        }
    }
}
