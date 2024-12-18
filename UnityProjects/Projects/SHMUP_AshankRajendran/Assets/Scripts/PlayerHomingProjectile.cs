using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingProjectile : PlayerProjectile
{
    [SerializeField] EnemyShipController targetShip;
    [SerializeField] float pursueTime = 0.5f;
    [SerializeField] float rotationSpeedInDegrees = 720;
    [SerializeField] float pursueWeightage = 1.5f;

    private void Awake()
    {
        targetShip = CustomCollisionManager.instance.GetEnemyShip();
        velocity = projectileDirection * projectileSpeed;
    }

    protected override void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, rotationSpeedInDegrees * Time.deltaTime);

        if (targetShip != null)
        {
            AddForceToProjectile(Pursue(targetShip.transform, targetShip.Velocty, pursueTime) * pursueWeightage);
        }
        else
        {
            targetShip = CustomCollisionManager.instance.GetEnemyShip();
        }

        velocity += acceleration * Time.deltaTime;

        transform.position += ((Vector3)velocity) * Time.deltaTime;

        acceleration = Vector2.zero;
    }
}

