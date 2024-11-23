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

        if (targetDistanceSquared < (target.physicsObject.radius + physicsObject.radius) * (target.physicsObject.radius + physicsObject.radius))
        {
            TeleportToRandomPosOnScreen();
        }

        return Flee(target);
    }

    //Returns 
    private void TeleportToRandomPosOnScreen()
    {
        Camera cam = Camera.main;
        Vector2 RandomPosInScreenSpace = new Vector2(Random.Range(0, cam.pixelWidth), Random.Range(0, cam.pixelHeight));
        Vector2 RandomPosInWorldSpace = cam.ScreenToWorldPoint(RandomPosInScreenSpace);

        physicsObject.Position = RandomPosInWorldSpace;
    }

    protected override void Init()
    {
    }
}
