using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Agent : MonoBehaviour
{
    [SerializeField] public PhysicsObject physicsObject;
    [SerializeField] protected Agent target;
    [SerializeField] protected Vector3 ultimaForce;
    [SerializeField] float maxForce = 100;

    protected Vector3 wanderForce;

    [SerializeField] protected float wanderTime = 1;
    [SerializeField] protected float wanderRadius = 1;
    [SerializeField] protected float currentWanderAngle = 0;
    [SerializeField] protected float maxWanderAngle = Mathf.PI * 2;
    [SerializeField] protected float stayInBoundsForceWeightage = 1;
    [SerializeField] protected Vector3 currentFuturePos;
    [SerializeField] protected Vector3 currentTargetPos;

    [SerializeField] protected float borderPadding = 1;

    protected abstract Vector3 CalcSteeringForce();

    private void Start()
    {
        Init();
    }

    protected abstract void Init();

    protected void Update()
    {
        ultimaForce = Vector3.zero;

        ultimaForce += CalcSteeringForce();
        ultimaForce += StayInBounds();

        Vector3.ClampMagnitude(ultimaForce, maxForce);

        physicsObject.ApplyForce(ultimaForce);
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

    protected Vector3 Seek(Vector3 targetPos)
    {
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
        Vector3 fleeingForce = desiredVelocity - physicsObject.Velocity;

        // Return seek steering force
        return fleeingForce;
    }

    protected Vector3 Flee(Vector3 targetPos)
    {

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

    protected Vector3 Wander(float time, float radius, float wanderRange)
    {
        //Choose a distance ahead
        Vector3 futurePos = CalcFuturePosition(time);

        //"Project a circle" into that space
        //What radius works best? Do radii have an effect on agent's movement?
        //Get a random angle to determine displacement vector
        float randAngle = currentWanderAngle + Random.Range(-wanderRange, wanderRange);
        currentWanderAngle = randAngle;

        if (currentWanderAngle > maxWanderAngle)
        {
            currentWanderAngle = maxWanderAngle;
        }
        else if (currentWanderAngle < -maxWanderAngle)
        {
            currentWanderAngle = -maxWanderAngle;
        }

        //Where would that displacement vector end?  Go there.
        Vector3 targetPos = futurePos;
        targetPos.x += Mathf.Cos(currentWanderAngle) * radius;
        targetPos.y += Mathf.Sin(currentWanderAngle) * radius;

        currentFuturePos = futurePos;
        currentTargetPos = targetPos;

        return Seek(targetPos);
        // Need to return a force - how do I get that?
    }

    protected Vector3 StayInBounds()
    {
        Vector3 lowerbounds = physicsObject.lowerBoundaries;
        Vector3 upperBounds = physicsObject.upperBoundaries;

        Vector3 stayInBoundsForce = Vector3.zero;

        if (currentFuturePos.x < lowerbounds.x + borderPadding || currentFuturePos.x > upperBounds.x - borderPadding)
        {
            stayInBoundsForce += Flee(currentFuturePos) * stayInBoundsForceWeightage;
        }

        if (currentFuturePos.y < lowerbounds.y + borderPadding || currentFuturePos.y > upperBounds.y - borderPadding)
        {
            stayInBoundsForce += Flee(currentFuturePos) * stayInBoundsForceWeightage;
        }

        return stayInBoundsForce;
    }

    public Vector3 CalcFuturePosition(float time)
    {
        return physicsObject.Velocity * time + transform.position;
    }
}
