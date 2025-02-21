using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private bool canFollow = true;
    private Transform target;
    private Transform followBoundery;
    private float smoothSpeed = 5f;

    public bool CanFollow{
        get{return canFollow;}
        set{this.canFollow = value;}
    }
    void Awake()
    {
        
    }
    void OnEnable(){

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
    private void FollowPlayer(){

    }
    private void StopAtBoundery(){

    }
}
