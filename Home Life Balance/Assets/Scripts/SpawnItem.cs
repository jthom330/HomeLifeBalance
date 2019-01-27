using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
	public GameObject[] drops;
	private GameObject holding;
    private Vector3 oldScale;
    public Vector3 smallScale = Vector2.one* 0.04f;

    private Quaternion rot;


    void Spawn()
	{
        rot = Quaternion.identity;
        int index = Random.Range(0, drops.Length);
        if (drops.Length > 1)
        {
            if (index == 0 || index == 1 || index == 4 || index == 5 || index == 7)
            {
                rot = Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 4) * 90);
            }
        }

        holding = Instantiate(drops[index], transform.position, Quaternion.identity);
        holding.transform.parent = gameObject.transform;

        holding.transform.rotation = rot;

        oldScale = holding.transform.lossyScale;
        smallScale.x = smallScale.x * Mathf.Sign(oldScale.x);
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
            holding.transform.rotation = Quaternion.identity;
            holding.transform.localScale = oldScale;
            holding.transform.rotation = rot;

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
            holding.SetActive(false);
        }

    }
}
