using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    [SerializeField]
    bool lockXRotation = false;
    [SerializeField]
    bool lockYRotation = false;
    [SerializeField]
    bool lockZRotation = false;


    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.y, transform.eulerAngles.y, 0);

    }
}

