using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCheck : MonoBehaviour
{

    public float resetTimer = 10f;

    private void Update()
    {
        resetTimer -= Time.deltaTime;
        if (resetTimer <= 0)
        {
            //remove roof option 
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        resetTimer = 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlacedBlock")
        {
            collision.GetComponent<BlockTimer>().StartTimer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlacedBlock")
        {
            collision.GetComponent<BlockTimer>().StopTimer();
        }
    }
}
