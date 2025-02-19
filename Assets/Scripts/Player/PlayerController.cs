using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool canMove = true;
    private bool canAttack = true;
    private CharacterController controller;

    public bool CanMove{
        get{return canMove;}
        set{this.canMove = value;}
    }
    public bool CanAttack{
        get{return canAttack;}
        set{this.canAttack = value;}
    }

    void OnEnable(){
        
    }
    void OnDisable(){

    }
    void Awake(){
        controller = GetComponent<CharacterController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove){
            BasicMovement();
            Jumping();
            Attacking();
        }
        
    }
    private void BasicMovement(){

    }
    private void Jumping(){

    }
    private void Attacking(){

    }
}
