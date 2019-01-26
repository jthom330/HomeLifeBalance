using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
	public GameObject roofSpawner;
	
    // Start is called before the first frame update
    void Start()
    {
        roofSpawner = GameObject.Find("UIBoxSpecial");
		roofSpawner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
