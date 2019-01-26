using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionBehavior : MonoBehaviour
{
    public GameObject destroyEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlacedBlock")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            ContactPoint2D contact = collision.contacts[0];
            StartCoroutine(AnimateAndDestroy(contact.point, collision.gameObject));
        }
    }

    IEnumerator AnimateAndDestroy(Vector2 point, GameObject block)
    {
        GameObject instance = Instantiate(destroyEffect, block.transform.position, Quaternion.identity);
        instance.transform.localScale = Vector2.zero;
        float ElapsedTime = 0.0f;
        float TotalTime = 0.5f;
        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            instance.transform.localScale = Vector2.Lerp(instance.transform.localScale, Vector2.one, (ElapsedTime / TotalTime));
            yield return null;
        }

        Destroy(block);
        ElapsedTime = 0.0f;

        while (ElapsedTime < TotalTime)
        {
            ElapsedTime += Time.deltaTime;
            instance.transform.localScale = Vector2.Lerp(instance.transform.localScale, Vector2.zero, (ElapsedTime / TotalTime));
            yield return null;
        }

        Destroy(instance);
    }
}
