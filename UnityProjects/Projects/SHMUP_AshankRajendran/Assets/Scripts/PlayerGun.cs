using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectileSpawnLocation;
    [SerializeField] Vector2 spawnLocationOffset;

    private PlayerInputActions inputActions;
    private bool isFiring;
    public float fireRate = 0.2f; // Seconds between shots

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Fire.started += OnFireStarted;
        inputActions.Player.Fire.canceled += OnFireCanceled;
    }

    private void OnDisable()
    {
        inputActions.Player.Fire.started -= OnFireStarted;
        inputActions.Player.Fire.canceled -= OnFireCanceled;
        inputActions.Disable();
    }

    void OnFireStarted(InputAction.CallbackContext context)
    {
        isFiring = true;
        InvokeRepeating(nameof(Fire), 0f, fireRate);
    }

    void OnFireCanceled(InputAction.CallbackContext context)
    {
        isFiring = false;
        CancelInvoke(nameof(Fire));
    }

    private void Fire()
    {
        if (isFiring)
        {
            Instantiate(projectilePrefab, projectileSpawnLocation.position, Quaternion.identity);
        }
    }
}
