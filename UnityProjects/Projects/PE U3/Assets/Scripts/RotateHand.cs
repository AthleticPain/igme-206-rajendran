using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    private float turnAmount = 6; //6 degrees per second
    [SerializeField] bool useDeltaTime;

    private void Update()
    {
        if (useDeltaTime)
        {
            transform.Rotate(0, 0, turnAmount * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, turnAmount);
        }
    }
}
