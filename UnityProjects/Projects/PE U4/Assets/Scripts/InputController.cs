using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputController : MonoBehaviour
{
    [SerializeField] MovementController myMovementController;
    private Vector2 inputDirection;

    private void Start()
    {
        if(myMovementController == null)
        {
            myMovementController = GetComponent<MovementController>();
        }
    }

    // The method that gets called to handle any player movement input
    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the latest value for the input from the Input System
        inputDirection = context.ReadValue<Vector2>();  // This is already normalized for us

        // Send that new direction to the Vehicle class
        myMovementController.SetDirection(inputDirection);
    }

}
