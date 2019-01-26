using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringController : MonoBehaviour
{
    public int objectValue = 10;
    private bool scoreApplied = false;
    List<GameObject> currentCollisions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCollisions.Count > 0 && !scoreApplied)
        {
            ScoreManager.score += objectValue;
            scoreApplied = true;
        }
        if (currentCollisions.Count <= 0 && scoreApplied)
        {
            ScoreManager.score -= objectValue;
            scoreApplied = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlacedBlock")
        {
            currentCollisions.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlacedBlock")
        {
            currentCollisions.Remove(collision.gameObject);
        }
    }
}
