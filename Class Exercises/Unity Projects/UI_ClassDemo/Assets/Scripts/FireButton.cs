using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    //  A reference to the button to turn on/off
    [SerializeField]
    Button button;

    //  A reference to the sprite to use as a cooldown timer
    [SerializeField]
    Image timerImage;

    //  Values to keep track of the cooldown
    float cooldownTimer;
    float cooldownTime;

    // Update is called once per frame
    void Update()
    {
        //  Update the cooldown timer if active
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;

            //  Get the percent of time on the cooldown
            timerImage.fillAmount = (cooldownTime - cooldownTimer) / cooldownTime;

            //  Check if the cooldown is over
            if(cooldownTimer <= 0)
            {
                button.interactable = true;
            }
        }
    }

    /// <summary>
    /// Fire the lasers!
    /// </summary>
    /// <param name="time">The cooldown time for the laser</param>
    public void Fire(int time)
    {
        Debug.Log("FIRE!");

        button.interactable = false;

        cooldownTime = time;
        cooldownTimer = time;
    }
}
