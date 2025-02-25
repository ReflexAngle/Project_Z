using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSCript : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect; //speed at which the bg moves relative to the camera
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with camera || 1 = wont move with camera || 0.5 = halfspeed
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
