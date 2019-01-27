using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCheck : MonoBehaviour
{

    public float resetTimer = 2f;

    private void Update()
    {
        resetTimer -= Time.deltaTime;
        if (resetTimer <= 0)
        {
            //remove roof option
			//Debug.LogFormat("Remove roof: {0}", GameObject.Find("Tracker"));
			GameObject.Find("Tracker").GetComponent<Tracker>().roofSpawner.SetActive(false);			
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
		if(collision.tag == "PlacedBlock")
        {
			//Debug.LogFormat("collisionBlock stay: {0}", collision.transform.position);
            collision.GetComponent<BlockTimer>().StartTimer();
        }
        resetTimer = 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlacedBlock")
        {
			//Debug.LogFormat("collisionBlock enter: {0}", collision.transform.position);
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
