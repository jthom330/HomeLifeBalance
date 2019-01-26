using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{

    public float localGravityScale = 1;
    public float speed = 10;
    // Start is called before the first frame update

    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void OnMouseDrag()
    {
        var pos = Input.mousePosition;        
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;

        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = localGravityScale;
    }
}
