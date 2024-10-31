using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField] GameObject clockNumberPrefab;
    [SerializeField] float radius;

    private void Start()
    {
        //First number spawns at 12 o clock
        float startingAngle = 90 * Mathf.Deg2Rad; //Converted to radians

        //Loop to instantiate each clock number starting from 12
        //Each loop, add 30 degrees (counter clockwise), and change text to be same as i
        // i decrements each loop till 1 in descending order (12, 11, 10, 9, 8...)
        for (int i = 12; i > 0; i--)
        {
            float xCoordinate = Mathf.Cos(startingAngle) * radius;
            float yCoordinate = Mathf.Sin(startingAngle) * radius;

            //Spawn clock number prefab
            //Spawn location at center of this transform + (xCoordinate, yCoordinate)
            //Instantiate as a child of this transform
            GameObject newClockNumber = Instantiate(clockNumberPrefab,
                transform.position + new Vector3(xCoordinate, yCoordinate, 0),
                Quaternion.identity,
                transform);

            newClockNumber.GetComponent<TextMesh>().text = i.ToString(); //Change textmesh text to correct number

            startingAngle += 30 * Mathf.Deg2Rad; //Converted to radians
        }
    }
}
