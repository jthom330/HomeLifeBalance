using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTimer : MonoBehaviour
{
    public float countDown = 10;
    private float currentTime = 0;
    private bool isAtHeight = false;
    
    // Update is called once per frame
    void Update()
    {
        if (isAtHeight)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= countDown)
            {
				GameObject.Find("Tracker").GetComponent<Tracker>().roofSpawner.SetActive(true);
                Debug.LogFormat("min height achieved {0}", ":smiley:");
				//Instantiate(roofSpawner);
            }
        }
    }

    public void StartTimer()
    {
        isAtHeight = true;
    }

    public void StopTimer()
    {
        isAtHeight = false;
        currentTime = 0;
    }
}
