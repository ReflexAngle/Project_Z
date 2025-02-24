using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshConstraint : MonoBehaviour
{
    [SerializeField] private float sampleRadius  = 1f;
    [SerializeField] private float allowedDistance = .5f;
    // Start is called before the first frame update

    public bool IsValidDestination(Vector3 desiredPosition){
        NavMeshHit hit;
        if(NavMesh.SamplePosition(desiredPosition, out hit, sampleRadius, NavMesh.AllAreas )){
            return Vector3.Distance(hit.position, desiredPosition) < allowedDistance;

        }
        return false;
    }
}
