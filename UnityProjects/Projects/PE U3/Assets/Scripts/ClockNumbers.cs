using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    [SerializeField] GameObject clockNumberPrefab;

    private void Start()
    {
        for(int i = 0; i< 12; i++)
        {
            GameObject newClockNumber = Instantiate(clockNumberPrefab, );
        }
    }
}
