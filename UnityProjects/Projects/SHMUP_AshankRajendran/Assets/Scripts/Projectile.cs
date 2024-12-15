using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected Vector2 projectileDirection = Vector2.right;
    [SerializeField] protected Vector2 velocity;
    [SerializeField] protected Vector2 acceleration;
    [SerializeField] protected float projectileSpeed = 1;
    [SerializeField] protected int damageValue = 1;
    [SerializeField] CustomCollider _collider;

    private void OnEnable()
    {
        _collider.OnCollisionDetected += OnCustomCollision;
    }

    private void OnDisable()
    {
        _collider.OnCollisionDetected -= OnCustomCollision;
    }

    private void Awake()
    {
        if(!_collider)
        {
            _collider = GetComponent<CustomCollider>();
        }

        transform.eulerAngles = new Vector3(0, 0, 90 * -projectileDirection.x);
    }

    protected virtual void Update()
    {
        //transform.position += projectileDirection * projectileSpeed * Time.deltaTime;
        velocity += acceleration * Time.deltaTime;
        transform.position += (((Vector3)projectileDirection * projectileSpeed) + (Vector3)velocity) * Time.deltaTime;

        acceleration = Vector2.zero;
    }

    public void AddForceToProjectile(Vector2 force)
    {
        acceleration += force;
    }

    protected Vector3 Seek(Transform target)
    {
        Vector2 targetPos = target.position;
        Vector2 myPos = transform.position;

        // Calculate desired velocity
        Vector2 desiredVelocity = targetPos - myPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * projectileSpeed;

        // Calculate seek steering force
        Vector2 seekingForce = desiredVelocity - velocity;

        // Return seek steering force
        return seekingForce;
    }

    protected abstract void OnCustomCollision(CustomCollider other);

}
