using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSlider : MonoBehaviour
{
    /// <summary>
    /// A fucntion to handle the change in a value
    /// </summary>
    /// <param name="value">the new vaule</param>
    public void OnChange(float value)
    {
        Debug.Log(value);
    }
}
