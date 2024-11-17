using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseTracker : MonoBehaviour
{
    public float forceStrength = 1;
    [SerializeField] PhysicsObject physicsObject;

    private void Start()
    {
        if (!physicsObject)
        {
            physicsObject = GetComponent<PhysicsObject>();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosInScreenSpace = Input.mousePosition;
            Vector3 mousePosInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(mousePosInScreenSpace.x, mousePosInScreenSpace.y, 0));

            Vector3 forceDirection = mousePosInWorldSpace - physicsObject.Position;
            forceDirection = new Vector3(forceDirection.x, forceDirection.y, 0).normalized;

            Debug.Log("Applying force towards mouse: " + forceDirection);
            physicsObject.ApplyForce(forceDirection * forceStrength);
        }
    }
}
