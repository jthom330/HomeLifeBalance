using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePannable : MonoBehaviour
{
    public float sensitivity;
    private Vector3 lastCameraPosition;
    public string tagThatBlocksPanning = "UnplacedBlock";
    public bool pannable;
    private int activeChildCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeChildCount = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
                activeChildCount++;
        }
        if (GameObject.FindGameObjectsWithTag(tagThatBlocksPanning).Length <= activeChildCount)
        {
            pannable = true;
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
        else {
            pannable = false;
        }
    }
}
