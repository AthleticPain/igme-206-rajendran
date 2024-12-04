using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] Ship playerShip;
    [SerializeField] float damageForceMagnitude = 4000;
    [SerializeField] CustomCollider _collider;

    private void Awake()
    {
        if(!_collider)
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

    public void DealDamage(int damageValue, Vector3 direction)
    {
        playerShip.AddForceToShip(direction * damageForceMagnitude);
    }

    void Collision(CustomCollider other)
    {
        if(other.collisionLayer == CustomCollisionLayer.EnemyShip)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();

            DealDamage(1, -direction);
        }
    }
}
