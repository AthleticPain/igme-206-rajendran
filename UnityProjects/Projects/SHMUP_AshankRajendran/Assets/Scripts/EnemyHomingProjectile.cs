using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingProjectile : EnemyProjectile
{
    Transform targetTransform;
    [SerializeField] float rotationSpeedInDegrees = 15;

    private void Awake()
    {
        targetTransform = CustomCollisionManager.instance.playerShipTransform;
    }

    protected override void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, rotationSpeedInDegrees * Time.deltaTime);

        if ((transform.position - targetTransform.position).x > 0)
        {
            AddForceToProjectile(Seek(targetTransform));
        }
        base.Update();
    }
}
