using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
	public GameObject[] drops;
	private GameObject holding;
    private Vector3 oldScale;
    public Vector3 smallScale = Vector2.one* 0.04f;
	
	void Spawn()
	{
        holding = Instantiate(drops[Random.Range(0, drops.Length)], transform.position, Quaternion.identity);
        holding.transform.parent = gameObject.transform;

        oldScale = holding.transform.lossyScale;
        holding.transform.localScale = smallScale;
        holding.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
	
	void OnTriggerExit2D(Collider2D other)
	{
        if (other.gameObject == holding)
        {
            holding.transform.parent = null;
            holding.transform.localScale = oldScale;
            holding.tag = "UnplacedBlock";

            Spawn();
        }
        else {
            holding.SetActive(true);
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject != holding && holding != null)
        {
            Debug.Log(other.gameObject.name + holding.name);
            holding.SetActive(false);
        }

    }
}
