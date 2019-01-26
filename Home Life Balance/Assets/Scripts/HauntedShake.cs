using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedShake : MonoBehaviour
{
    public float hauntedShakeDelay = 10f;
    private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "PlacedBlock")
        {
            currentTime += Time.deltaTime;

            if (currentTime >= hauntedShakeDelay)
            {
                StartCoroutine(DoShake());
                currentTime = 0;
            }
        }
    }

    IEnumerator DoShake()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        float thrust = 100f;
        rb.AddForce(Vector2.right * thrust);
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(Vector2.left * thrust);
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(Vector2.right * thrust);
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(Vector2.left * thrust);
    }
}
