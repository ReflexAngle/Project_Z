using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstraint : MonoBehaviour
{
    [SerializeField]private float fixedZ = -6f;
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ZAxisConstraint();
    }
    private void ZAxisConstraint(){
        transform.position = new Vector3(transform.position.x, transform.position.y, fixedZ);
    }
}
