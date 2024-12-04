using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] Vector3 projectileDirection = Vector3.right;
    [SerializeField] float projectileSpeed = 1;
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

    private void Update()
    {
        transform.position += projectileDirection * projectileSpeed * Time.deltaTime;
    }


    protected abstract void OnCustomCollision(CustomCollider other);

}
