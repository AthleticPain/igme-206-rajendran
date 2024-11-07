using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // Where is the vehicle
    Vector3 objectPosition = new Vector3(0, 0, 0);

    // How fast it should move in units per second
    [SerializeField] float speed = 4f;

    // Direction vehicle is facing, must be normalized
    Vector3 direction = new Vector3(0, 0, 0);   // or Vector3.zero

    // The delta in position for a single frame
    Vector3 velocity = new Vector3(0, 0, 0);   // or Vector3.zero

    // Variable that stores the camera gameobject
    private Camera cam;

    //upper and lower bounds of screen in world space
    public float maxWidth;
    public float minWidth;
    public float maxHeight;
    public float minHeight;

    // Start is called before the first frame update
    void Start()
    {
        //Assign the scene's main camera to cam variable
        cam = Camera.main;

        // Grab the GameObject’s starting position
        objectPosition = transform.position;

    }

    private void OnGUI()
    {
        //Convert the screen space lower and upper bounds to world space
        Vector3 lowerBounds = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 upperBounds = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, 0));

        //set lower and upper bound variables
        maxWidth = upperBounds.x;
        maxHeight = upperBounds.y;
        minWidth = lowerBounds.x;
        minHeight = lowerBounds.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity is direction * speed * deltaTime
        velocity = direction * speed * Time.deltaTime;

        // Add velocity to position 
        objectPosition += velocity;

        // Validate new calculated position

        // “Draw” this vehicle at that position
        transform.position = objectPosition;

        //Check if player has gone beyond map bounds and wrap them if so
        if (transform.position.x > maxWidth)
        {
            objectPosition = new Vector3(minWidth, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < minWidth)
        {
            objectPosition = new Vector3(maxWidth, transform.position.y, transform.position.z);
        }
        else if (transform.position.y > maxHeight)
        {
            objectPosition = new Vector3(transform.position.x, minHeight, transform.position.z);
        }
        else if (transform.position.y < minHeight)
        {
            objectPosition = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }

        // Set the vehicle’s rotation to match the direction
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction); // for 2D rotation
        }
    }

    public void SetDirection(Vector2 inputDirection)
    {
        direction = inputDirection;
    }

    public void SetPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }
}
