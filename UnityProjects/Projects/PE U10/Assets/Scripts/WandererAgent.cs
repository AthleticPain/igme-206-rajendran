using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandererAgent : Agent
{
    protected override Vector3 CalcSteeringForce()
    {
        return Wander(wanderTime, wanderRadius, 0.1f);
    }

    protected override void Init()
    {
        currentWanderAngle = Random.Range(0, Mathf.PI * 2);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Vector3 futurePos = CalcFuturePosition(wanderTime);

        Gizmos.DrawLine(currentFuturePos, currentTargetPos);
        Gizmos.DrawWireSphere(currentFuturePos, wanderRadius);
    }
}
