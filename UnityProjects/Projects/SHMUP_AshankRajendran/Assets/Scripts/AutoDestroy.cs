using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float time;

    private void Start()
    {
        Invoke(nameof(DestroyObject), time);
    }

    void DestrotObject()
    {
        Destroy(gameObject);
    }
}
