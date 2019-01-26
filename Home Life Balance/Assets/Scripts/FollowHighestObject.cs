using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowHighestObject : MonoBehaviour
{
    public string objectTag;
    public float cameraSpeed;
    public float verticalOffset;
    public float startingZoomDistance;
    public float maxZoomDistance;
    public float zoomFactor;

    private Vector3 newCameraPos;
    private float currentZoomDistance;
    private float newZoomDistance;
    private GameObject highestGameObject;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Camera>().orthographicSize = startingZoomDistance;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustCameraZoom();
        AdjustCameraPosition();
    }

    void AdjustCameraZoom()
    {
        currentZoomDistance = this.GetComponent<Camera>().orthographicSize;
        newZoomDistance = startingZoomDistance + (newCameraPos.y * zoomFactor);
        if (newZoomDistance > maxZoomDistance)
        {
            newZoomDistance = maxZoomDistance;
        }
        if (newZoomDistance < startingZoomDistance)
        {
            newZoomDistance = startingZoomDistance;
        }
        this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentZoomDistance, newZoomDistance, cameraSpeed * Time.deltaTime);
    }

    void AdjustCameraPosition() {
        highestGameObject = GameObject.FindGameObjectsWithTag(objectTag).OrderBy(highestGameObject => highestGameObject.transform.position.y).Last();
        newCameraPos = new Vector3(highestGameObject.transform.position.x, highestGameObject.transform.position.y + verticalOffset, transform.position.z);
        this.transform.position = Vector3.Lerp(transform.position, newCameraPos, cameraSpeed * Time.deltaTime);
    }
}
