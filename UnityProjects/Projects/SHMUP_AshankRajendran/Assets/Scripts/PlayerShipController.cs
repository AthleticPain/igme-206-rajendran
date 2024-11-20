using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] private float mass = 1;
    [SerializeField] private float horizontalAcceleration = 1;
    [SerializeField] private float verticalAcceleration = 1;
    [SerializeField] private float dragCoefficient = 0.5f;

    [SerializeField] Vector2 inputValue;

    [SerializeField] private Vector2 acceleration;
    [SerializeField] private Vector2 velocity;

    [SerializeField] RocketTrail rocketTrail;

    private Vector2 minBounds, maxBounds;
    private Camera mainCamera;
    private Vector2 previousResolution;

    SpriteRenderer spriteRenderer;
    float spriteWidthFromCenter, spriteHeightFromCenter;

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
    void Update()
    {
        ApplyDrag();
        ProcessInput();

        velocity += acceleration * Time.deltaTime;

        transform.position += (Vector3)velocity * Time.deltaTime;

        CheckBounds();

        acceleration = Vector2.zero;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();

        rocketTrail.ChangeTrailLifetime(inputValue.x >= 0);
    }

    public void AddForceToPlayer(Vector2 force)
    {
        acceleration += force / mass;
    }

    private void ProcessInput()
    {
        acceleration += new Vector2(horizontalAcceleration * inputValue.x, verticalAcceleration * inputValue.y);
    }

    private void ApplyDrag()
    {
        Vector2 dragForce = dragCoefficient * -velocity * velocity.magnitude;
        AddForceToPlayer(dragForce);
    }

    private void CheckBounds()
    {
        if (transform.position.x - spriteWidthFromCenter < minBounds.x)
        {
            transform.position = new Vector2(minBounds.x + spriteWidthFromCenter, transform.position.y);
        }
        else if(transform.position.x + spriteWidthFromCenter > maxBounds.x)
        {
            transform.position = new Vector2(maxBounds.x - spriteWidthFromCenter, transform.position.y);

        }

        if(transform.position.y - spriteHeightFromCenter < minBounds.y)
        {
            transform.position = new Vector2(transform.position.x, minBounds.y + spriteHeightFromCenter);
        }
        else if (transform.position.y + spriteHeightFromCenter > maxBounds.y)
        {
            transform.position = new Vector2(transform.position.x, maxBounds.y - spriteHeightFromCenter);
        }
    }

    private IEnumerator CheckResolutionChange()
    {
        while(true)
        {
            if(Screen.width != previousResolution.x || Screen.height != previousResolution.y)
            {
                UpdateLevelBounds();
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

}
