using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : Ship
{
    [SerializeField] EnemyMovementPath enemyMovementPath;
    [SerializeField] Transform currentTarget;
    int currentTargetIndex = 0;
    [SerializeField] float waypointDelta = 0.5f;

    public void SetEnemyMovementPath(EnemyMovementPath enemyMovementPath)
    {
        this.enemyMovementPath = enemyMovementPath;
        currentTargetIndex = 0;
        currentTarget = this.enemyMovementPath.waypoints[0];
    }

    protected override void Update()
    {
        if (currentTarget)
        {
            AddForceToShip(Seek(currentTarget));

            if ((currentTarget.position - transform.position).magnitude < waypointDelta)
            {
                currentTargetIndex = (currentTargetIndex + 1) % enemyMovementPath.waypoints.Count;
                currentTarget = enemyMovementPath.waypoints[currentTargetIndex];
            }
        }

        if(!areBoundsActive)
        {
            UpdateBoundsAfterShipHasEntered();
        }

        base.Update();
    }

    void UpdateBoundsAfterShipHasEntered()
    {
        if (transform.position.x - spriteWidthFromCenter > minBounds.x && transform.position.x + spriteWidthFromCenter < maxBounds.x
            && transform.position.y - spriteHeightFromCenter > minBounds.y && transform.position.y + spriteHeightFromCenter > maxBounds.y)
        {
            areBoundsActive = true;
        }
    }
}
