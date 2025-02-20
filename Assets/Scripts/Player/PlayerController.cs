using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool canMove = true;
    private bool canAttack = true;
    private bool canJump = true;
    [SerializeField] private int lockVeritcalMove;
    [SerializeField] private float speed = 5f;
    private float gravity = 9.81f;
    private Vector2 moveDirection = Vector2.zero;
    private CharacterController controller;
    public InputControlls playerControlls;
    private InputAction move;


    public bool CanMove{
        get{return canMove;}
        set{this.canMove = value;}
    }
    public bool CanAttack{
        get{return canAttack;}
        set{this.canAttack = value;}
    }
    public bool CanJump{
        get{return canJump;}
        set{this.canJump = value;}
    }
    public int LockVeritcalMove{
        get{return lockVeritcalMove;}
        set{this.lockVeritcalMove = value;}
    }

    void OnEnable(){
        move = playerControlls.Movement.WASD;

        move.Enable();
    }
    void OnDisable(){
        move.Disable();

    }
    void Awake(){
        controller = GetComponent<CharacterController>();
        playerControlls = new InputControlls();

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
        moveDirection = move.ReadValue<Vector2>();    

        Vector3 _move = new Vector3(moveDirection.x, moveDirection.y, 0);
        controller.Move(_move * speed * Time.deltaTime);

    }
    private void LockVerticalMove(){

    }
    private void Jumping(){
        if(CanJump){

        }

    }
    private void Attacking(){
        if(CanAttack){

        }

    }
}
