using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleerAgent : Agent
{
    protected override Vector3 CalcSteeringForce()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 myPos = transform.position;

        float targetDistanceSquared = (myPos.x - targetPos.x) * (myPos.x - targetPos.x) + (myPos.y - targetPos.y) * (myPos.y - targetPos.y);

        if(targetDistanceSquared < physicsObject.radius * physicsObject.radius)
        {
            //Teleport logic here
        }

        return Flee(target);
    }
}
