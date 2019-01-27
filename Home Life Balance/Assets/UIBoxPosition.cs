using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBoxPosition : MonoBehaviour
{
    public Camera camera;
    public float offsetx = 0;
    public float offsety = 0;
    private Vector3 startingScale;

    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.localScale;
        //startingCameraSize = camera.size;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = camera.ViewportToWorldPoint(new Vector2(.5f + offsetx, 1f-offsety));
        newPos.z = 10;
        transform.position = newPos;
        transform.localScale = new Vector2(camera.orthographicSize/ startingScale.x, camera.orthographicSize/ startingScale.y);
    }
}
