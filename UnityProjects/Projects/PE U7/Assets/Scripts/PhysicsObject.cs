using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    //All fields
    Vector3 position;
    Vector3 direction;
    Vector3 velocity;
    Vector3 acceleration;
    float mass;

    [SerializeField] bool isFrictionActive = true;
    [SerializeField] bool isGravityActive = true;

    [SerializeField] float gravityStrength = 10;
    [SerializeField] float maxSpeed = 100;

    Vector2 minBounds;
    Vector2 maxBounds;

    private void OnGUI()
    {
        
    }

    private void Update()
    {
        
    }

    private void Bounce()
    {

    }

}
