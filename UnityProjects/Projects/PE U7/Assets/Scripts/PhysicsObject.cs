using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    //All fields
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 direction;
    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 acceleration;
    [SerializeField] float mass;

    [SerializeField] bool isFrictionActive = true;
    [SerializeField] bool isGravityActive = true;

    [SerializeField] float gravityStrength = 10;
    [SerializeField] public float maxSpeed = 100;

    [SerializeField] Vector2 lowerBoundaries;
    [SerializeField] Vector2 upperBoundaries;

    [SerializeField] SpriteRenderer spriteRenderer;

    //Radius of the sprite, used in wall collision detection
    [SerializeField] public float radius;

    [SerializeField] float rotationOffsetInDegrees = -90;

    //Flag to show if monster is on a floor or wall, used for friction
    public bool isInContactWithSurface;

    [SerializeField] float coefficientOfFriction = 0.1f;

    Camera cam;

    public Vector3 Velocity
    {
        set
        {
            if (value.x > maxSpeed)
                value.x = maxSpeed;
            if (value.y > maxSpeed)
                value.y = maxSpeed;
            if (value.z > maxSpeed)
                value.z = maxSpeed;

            velocity = value;
        }

        get { return velocity; }
    }

    public Vector3 Position
    {
        set
        {
            position = value;
            transform.position = position;
        }
        get { return position; }

    }

    private void Start()
    {
        cam = Camera.main;

        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        radius = spriteRenderer.bounds.size.x / 2;
    }

    private void OnGUI()
    {
        if(!cam)
        {
            cam = Camera.main;
        }
        lowerBoundaries = cam.ScreenToWorldPoint(Vector2.zero);
        upperBoundaries = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, cam.pixelHeight));
    }

    private void Update()
    {
        ApplyGravity();
        ApplyFriction();

        Velocity += acceleration * Time.deltaTime;
        Position += Velocity * Time.deltaTime;
        direction = Velocity.normalized;

        RotateTowardsDirection();

        Bounce();

        acceleration = Vector3.zero;
    }

    private void ApplyGravity()
    {
        if (isGravityActive)
        {
            Vector3 gravityForce = new Vector3(0, -gravityStrength, 0);
            ApplyForce(gravityForce * mass);
        }
    }

    private void ApplyFriction()
    {
        isInContactWithSurface = IsBodyInContactWithSurface();

        if (isFrictionActive && isInContactWithSurface)
        {
            Vector3 frictionForce = Velocity * -1;
            frictionForce.Normalize();
            frictionForce = frictionForce * coefficientOfFriction;

            ApplyForce(frictionForce);
        }
    }

    private void Bounce()
    {
        //If object is outside x bounds, reverse the x velocity
        if (transform.position.x - radius < lowerBoundaries.x || transform.position.x + radius > upperBoundaries.x )

        {
            Velocity = new Vector3(Velocity.x * - 0.7f, Velocity.y, Velocity.z);
        }

        //If object is outside of the y bounds, reverse the y velocity
        if(transform.position.y - radius < lowerBoundaries.y || transform.position.y + radius > upperBoundaries.y)
        {
            Velocity = new Vector3(Velocity.x, Velocity.y * -0.7f, Velocity.z);
        }
    }

    //Checks if an object is in contact with any of the boundaries
    //Prevents object from sinking through the boundaries
    private bool IsBodyInContactWithSurface()
    {
        bool isInContact = false;
        if (Position.y - radius < lowerBoundaries.y)
        {
            Position = new Vector3(Position.x, lowerBoundaries.y + radius, Position.z);
            isInContact = true;
        }
        if (Position.y + radius > upperBoundaries.y)
        {
            Position = new Vector3(Position.x, upperBoundaries.y - radius, Position.z);
            isInContact = true;
        }
        if (Position.x - radius < lowerBoundaries.x)
        {
            Position = new Vector3(lowerBoundaries.x + radius, Position.y , Position.z);
            isInContact = true;
        }
        if (Position.x + radius > upperBoundaries.x)
        {
            Position = new Vector3(upperBoundaries.x - radius, Position.y , Position.z);
            isInContact = true;
        }

        return isInContact;

    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    private void RotateTowardsDirection()
    {
        //transform.rotation = Quaternion.LookRotation(direction);

        float rotationAngle = Mathf.Atan2(Velocity.y, Velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle + rotationOffsetInDegrees);
    }

}
