using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCheck : MonoBehaviour
{  
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
