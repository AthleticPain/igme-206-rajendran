using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Ship : MonoBehaviour
{
    [SerializeField] private float mass = 1;
    [SerializeField] protected float horizontalAcceleration = 1;
    [SerializeField] protected float verticalAcceleration = 1;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] private float dragCoefficient = 0.5f;

    [SerializeField] private Vector2 acceleration;
    [SerializeField] private Vector2 velocity;

    [SerializeField] protected RocketTrail rocketTrail;

    [SerializeField] protected bool areBoundsActive = true;

    [SerializeField] GameObject destroyedVFX;
    protected Vector2 minBounds, maxBounds;
    private Camera mainCamera;
    private Vector2 previousResolution;

    SpriteRenderer spriteRenderer;
    protected float spriteWidthFromCenter, spriteHeightFromCenter;

    public Vector2 Velocty
    {
        get { return velocity; }
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        UpdateLevelBounds();
        StartCoroutine(CheckResolutionChange());
    }

    private void Start()
    {
        mainCamera = Camera.main;

        if (!spriteRenderer)
            spriteRenderer = GetComponent<SpriteRenderer>();

        spriteWidthFromCenter = spriteRenderer.size.x / 2;
        spriteHeightFromCenter = spriteRenderer.size.y / 2;
    }

    private void UpdateLevelBounds()
    {
        previousResolution = new Vector2(Screen.width, Screen.height);
        minBounds = mainCamera.ScreenToWorldPoint(Vector2.zero);
        maxBounds = mainCamera.ScreenToWorldPoint(new Vector2(mainCamera.pixelWidth, mainCamera.pixelHeight));
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ApplyDrag();

        velocity += acceleration * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        transform.position += (Vector3)velocity * Time.deltaTime;

        CheckBounds();

        acceleration = Vector2.zero;
    }


    public void AddForceToShip(Vector2 force)
    {
        acceleration += force / mass;
    }

    private void ApplyDrag()
    {
        Vector2 dragForce = dragCoefficient * -velocity * velocity.magnitude;
        AddForceToShip(dragForce);
    }

    protected Vector3 Seek(Transform target)
    {
        Vector2 targetPos = target.position;
        Vector2 myPos = transform.position;

        // Calculate desired velocity
        Vector2 desiredVelocity = targetPos - myPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Calculate seek steering force
        Vector2 seekingForce = desiredVelocity - velocity;

        // Return seek steering force
        return seekingForce;
    }

    private void CheckBounds()
    {
        if (areBoundsActive)
        {
            if (transform.position.x - spriteWidthFromCenter < minBounds.x)
            {
                transform.position = new Vector2(minBounds.x + spriteWidthFromCenter, transform.position.y);
            }
            else if (transform.position.x + spriteWidthFromCenter > maxBounds.x)
            {
                transform.position = new Vector2(maxBounds.x - spriteWidthFromCenter, transform.position.y);

            }

            if (transform.position.y - spriteHeightFromCenter < minBounds.y)
            {
                transform.position = new Vector2(transform.position.x, minBounds.y + spriteHeightFromCenter);
            }
            else if (transform.position.y + spriteHeightFromCenter > maxBounds.y)
            {
                transform.position = new Vector2(transform.position.x, maxBounds.y - spriteHeightFromCenter);
            }
        }
    }

    private IEnumerator CheckResolutionChange()
    {
        while (true)
        {
            if (Screen.width != previousResolution.x || Screen.height != previousResolution.y)
            {
                UpdateLevelBounds();
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SpawnDestructionVFX()
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
    }

}
