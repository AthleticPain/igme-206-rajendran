using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Agent : MonoBehaviour
{
    [SerializeField] public PhysicsObject physicsObject;
    [SerializeField] protected Agent target;

    protected abstract Vector3 CalcSteeringForce();

    protected void Update()
    {
        physicsObject.ApplyForce(CalcSteeringForce());
    }

    protected Vector3 Seek(Agent target)
    {
        Vector3 targetPos = target.transform.position;
        Vector3 myPos = transform.position;

        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - myPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;

        // Return seek steering force
        return seekingForce;
    }

    protected Vector3 Flee(Agent target)
    {
        Vector3 targetPos = target.transform.position;
        Vector3 myPos = transform.position;

        // Calculate desired velocity
        Vector3 desiredVelocity = myPos - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * physicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - physicsObject.Velocity;

        // Return seek steering force
        return seekingForce;
    }
}
