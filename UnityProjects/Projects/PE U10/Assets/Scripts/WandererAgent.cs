using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandererAgent : Agent
{
    [SerializeField] private List<Obstacle> obstacles;
    [SerializeField] private float avoidRadius = 2f;

    protected override void Init()
    {
        currentWanderAngle = Random.Range(0, Mathf.PI * 2);

        // Collect all obstacles in the scene
        obstacles = new List<Obstacle>(FindObjectsOfType<Obstacle>());
    }

    protected override Vector3 CalcSteeringForce()
    {
        Vector3 wanderForce = Wander(wanderTime, wanderRadius, 0.1f);
        Vector3 avoidanceForce = AvoidObstacles(obstacles, avoidRadius);

        // Combine wander and avoidance forces
        return wanderForce + avoidanceForce;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Vector3 futurePos = CalcFuturePosition(wanderTime);

        Gizmos.DrawLine(currentFuturePos, currentTargetPos);
        Gizmos.DrawWireSphere(currentFuturePos, wanderRadius);

        Gizmos.color = Color.red;
        foreach (var obstacle in obstacles)
        {
            Gizmos.DrawWireSphere(obstacle.transform.position, avoidRadius);
        }
    }

}
