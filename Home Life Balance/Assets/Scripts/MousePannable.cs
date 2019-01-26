using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePannable : MonoBehaviour
{
    public float sensitivity;
    private Vector3 lastCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            lastCameraPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastCameraPosition;
            transform.Translate(0, delta.y * -sensitivity, 0);
            lastCameraPosition = Input.mousePosition;
        }
    }
}
