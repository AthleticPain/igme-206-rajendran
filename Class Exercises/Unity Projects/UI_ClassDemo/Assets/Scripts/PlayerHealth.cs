using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;

    /// <summary>
    /// Lower the player's health by an amount
    /// </summary>
    /// <param name="value">The amount health to take away</param>
    public void DecreaseHealth(float value)
    {
        healthSlider.value -= value;
    }
}
