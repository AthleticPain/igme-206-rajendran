using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField] GameObject creaturePrefab;
    [SerializeField] Transform[] spawnTransforms;


    private void Start()
    {
        foreach(Transform transform in spawnTransforms)
        {
            Instantiate(creaturePrefab, transform.position, Quaternion.identity);
        }
    }

}
