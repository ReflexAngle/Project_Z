using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// use a centralized constraint for multiple players and the enemies to prevent copying logic
public class NavMeshConstraint : MonoBehaviour
{
    public static NavMeshConstraint instance;
    [SerializeField] private float sampleRadius  = 1f;
    [SerializeField] private float allowedDistance = .5f;
    // Start is called before the first frame update

    private void Awake(){
        if (instance == null){ instance = this;}
        else { Destroy(gameObject);}
    }
    
    public bool IsValidDestination(Vector3 desiredPosition){
        NavMeshHit hit;
        if(NavMesh.SamplePosition(desiredPosition, out hit, sampleRadius, NavMesh.AllAreas )){
            return Vector3.Distance(hit.position, desiredPosition) < allowedDistance;

        }
        return false;
    }
}
