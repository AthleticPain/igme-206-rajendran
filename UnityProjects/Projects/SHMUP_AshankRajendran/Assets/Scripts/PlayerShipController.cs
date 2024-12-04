using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipController : Ship
{
    [SerializeField] Vector2 inputValue;

    // Update is called once per frame
    protected override void Update()
    {
        ProcessInput();
        base.Update();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();

        rocketTrail.ChangeTrailLifetime(inputValue.x >= 0);
    }

    private void ProcessInput()
    {
        AddForceToShip(new Vector2(horizontalAcceleration * inputValue.x, verticalAcceleration * inputValue.y));
    }

}
