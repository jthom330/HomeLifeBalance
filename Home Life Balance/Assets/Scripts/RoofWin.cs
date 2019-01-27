using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofWin : MonoBehaviour
{
    public float winCountDown = 10;
    private float currentTime = 0;

    private void Update()
    {
        if(currentTime >= winCountDown)
        {
            TimeManager.winConditionMet = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlacedBlock")
        {
            currentTime += Time.deltaTime;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlacedBlock")
        {
            currentTime = 0;
        }
    }
}
