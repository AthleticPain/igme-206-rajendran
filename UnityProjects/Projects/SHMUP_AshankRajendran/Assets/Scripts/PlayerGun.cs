using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject primaryProjectilePrefab;
    [SerializeField] GameObject secondaryProjectilePrefab;

    [SerializeField] Transform projectileSpawnLocation;
    [SerializeField] Vector2 spawnLocationOffset;

    private PlayerInputActions inputActions;
    private bool isFiringPrimary;
    private bool isFiringSecondary;
    public float primaryFireRate = 0.2f; // Seconds between shots for primary projectile
    public float secondaryFireRate = 2f; // Seconds between shots for secondary projectile

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Fire.started += OnPrimaryFireStarted;
        inputActions.Player.Fire.canceled += OnPrimaryFireCanceled;

        inputActions.Player.Fire2.started += OnSeccondaryFireStarted;
        inputActions.Player.Fire2.canceled += OnSeondaryFireCanceled;
    }

    private void OnDisable()
    {
        inputActions.Player.Fire.started -= OnPrimaryFireStarted;
        inputActions.Player.Fire.canceled -= OnPrimaryFireCanceled;

        inputActions.Player.Fire2.started -= OnSeccondaryFireStarted;
        inputActions.Player.Fire2.canceled -= OnSeondaryFireCanceled;

        inputActions.Disable();
    }

    void OnPrimaryFireStarted(InputAction.CallbackContext context)
    {
        isFiringPrimary = true;
        InvokeRepeating(nameof(FirePrimary), 0f, primaryFireRate);
    }

    void OnPrimaryFireCanceled(InputAction.CallbackContext context)
    {
        isFiringPrimary = false;
        CancelInvoke(nameof(FirePrimary));
    }

    void OnSeccondaryFireStarted(InputAction.CallbackContext context)
    {
        isFiringSecondary = true;
        InvokeRepeating(nameof(FireSecondary), 0f, secondaryFireRate);
    }

    void OnSeondaryFireCanceled(InputAction.CallbackContext context)
    {
        isFiringSecondary = false;
        CancelInvoke(nameof(FireSecondary));
    }

    private void FirePrimary()
    {
        if (isFiringPrimary)
        {
            Instantiate(primaryProjectilePrefab, projectileSpawnLocation.position, Quaternion.identity);
        }
    }

    private void FireSecondary()
    {
        if (isFiringSecondary)
        {
            Instantiate(secondaryProjectilePrefab, projectileSpawnLocation.position, Quaternion.identity);
        }
    }
}
