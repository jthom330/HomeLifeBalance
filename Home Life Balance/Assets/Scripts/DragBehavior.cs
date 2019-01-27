using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{

    public float localGravityScale = 1;
    public float speed = 10;
    public bool pickup = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        if (pickup)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void OnMouseDrag()
    {
        if (pickup)
        {
            var pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = 0;

            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }
    }

    private void OnMouseUp()
    {
        if (pickup)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = localGravityScale;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.tag = "PlacedBlock";
            pickup = false;
        }
    }
}
