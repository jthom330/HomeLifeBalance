using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FollowHighestObject : MonoBehaviour
{
    public string tag;
    public float cameraSpeed;
    private Vector3 newCameraPos;
    private GameObject highestGameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highestGameObject = GameObject.FindGameObjectsWithTag(tag).OrderBy(highestGameObject => highestGameObject.transform.position.y).Last();
        newCameraPos = new Vector3(highestGameObject.transform.position.x, highestGameObject.transform.position.y, transform.position.z);
        this.transform.position = Vector3.Lerp(transform.position, newCameraPos, cameraSpeed * Time.deltaTime);
    }
}
