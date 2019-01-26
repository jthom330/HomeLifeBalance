using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
	public GameObject[] drops;
	private GameObject holding;
	
	void Spawn()
	{
		holding = Instantiate(drops[Random.Range(0, drops.Length)], transform.position, Quaternion.identity);
		holding.transform.parent = gameObject.transform;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == holding)
		{
			Debug.LogFormat("Instantiate new item: {0}", drops);
			Spawn();
		}
	}
}
