using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testButton : MonoBehaviour
{
    /// <summary>
    /// Print "Hi!" to the console
    /// </summary>
    public void SayHi()
    {
        Debug.Log("Hi!");
    }

    /// <summary>
    /// Print a string to the console
    /// </summary>
    /// <param name="phrase">The string to print</param>
    public void SaySomething(string phrase)
    {
        Debug.Log(phrase);
    }

    /// <summary>
    /// Print "Hey! Listen!" a number of times to the console
    /// </summary>
    /// <param name="num">The number of times to print</param>
    public void Repeat(int num)
    {
        for(int i = 0; i < num; ++i)
        {
            Debug.Log("Hey! Listen!");
        }
    }
}
