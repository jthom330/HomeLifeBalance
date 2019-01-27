using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehavior : MonoBehaviour
{

    public float localGravityScale = 1;
    public float speed = 10;
    public bool pickup = true;
    private float prevMouseX;
    private float currentMouseX;
    private float mouseSpeed = 0;
    Rigidbody2D objRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        objRigidBody = gameObject.GetComponent<Rigidbody2D>();
        objRigidBody.gravityScale = 0;
        prevMouseX = Input.mousePosition.x;
    }

    private void OnMouseDown()
    {
        objRigidBody.constraints = RigidbodyConstraints2D.None;
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
            objRigidBody.gravityScale = localGravityScale;
            objRigidBody.bodyType = RigidbodyType2D.Dynamic;
            objRigidBody.AddForce(transform.right * mouseSpeed);
            //gameObject.tag = "PlacedBlock";
            pickup = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlacedBlock" && gameObject.tag == "UnplacedBlock")
        {
            objRigidBody.gravityScale = localGravityScale;
            objRigidBody.bodyType = RigidbodyType2D.Dynamic;
            gameObject.tag = "PlacedBlock";
            pickup = false;
        }
    }

    public void Update() {
        currentMouseX = Input.mousePosition.x;
        mouseSpeed = (currentMouseX - prevMouseX);
        prevMouseX = currentMouseX;
    }
}
