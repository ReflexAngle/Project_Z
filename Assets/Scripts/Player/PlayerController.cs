using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private NavMeshConstraint navConstraint;
    private bool canMove = true;
    private bool canAttack = true;
    private bool canBlock = true;
    private bool canJump = true;
    private bool isGrounded = true;
    [SerializeField] private int lockVeritcalMove;
    [SerializeField] private float speed = 5f;
    private float gravity = 9.81f;
    private Vector2 moveDirection = Vector2.zero;
    [SerializeField] private Vector2 floorSize;
    private SpriteRenderer spriteRenderer;
    private CharacterController controller;
    public InputControlls playerControlls;
    private InputAction move;
    private InputAction jump;
    private InputAction attack;
    private InputAction block;

    public bool CanMove{ // can handle animations like idle, stun, or walking
        get{return canMove;}
        set{this.canMove = value;}
    }
    public bool CanAttack{
        get{return canAttack;}
        set{this.canAttack = value;}
    }
    public bool CanBlock{
        get{return canBlock;}
        set{this.canBlock = value;}
    }
    public bool CanJump{
        get{return canJump;}
        set{this.canJump = value;}
    }
    public bool IsGrounded{ // handle the jump animations in here
        get{return isGrounded;}
        set{this.isGrounded = value;}
    }
    public int LockVeritcalMove{
        get{return lockVeritcalMove;}
        set{this.lockVeritcalMove = value;}
    }
    void Awake(){
        navConstraint = GetComponent<NavMeshConstraint>();
        controller = GetComponent<CharacterController>();
        playerControlls = new InputControlls();

        playerControlls.Movement.Jump.started += ctx => StartJumping();
        playerControlls.Movement.Jump.canceled += ctx => StartJumping();

        playerControlls.Movement.Attack.performed += ctx => Attacking();

        playerControlls.Movement.Block.started += ctx => Blocking();
    }
    void OnEnable(){
        move = playerControlls.Movement.WASD;
        jump = playerControlls.Movement.Jump;
        attack = playerControlls.Movement.Attack;
        block = playerControlls.Movement.Block;

        move.Enable();
        jump.Enable();
        attack.Enable();
        block.Enable();
    }
    void OnDisable(){
        move.Disable();
        jump.Disable();
        attack.Disable();
        block.Disable();
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
        } 
    }
    private void BasicMovement(){
        moveDirection = move.ReadValue<Vector2>();    

        Vector3 _move = new Vector3(moveDirection.x, 0, moveDirection.y);
        controller.Move(_move * speed * Time.deltaTime);
        Vector3 desiredPosition = transform.position + _move * speed * Time.deltaTime;

       if(navConstraint != null && navConstraint.IsValidDestination(desiredPosition)){
            controller.Move(_move * speed * Time.deltaTime);
        }

    }
    private void StartJumping(){
        if(CanJump && CanJump){

        }

    }
    private void EndJump(){

    }
    private void Attacking(){
        if(CanAttack && CanMove && CanBlock){
            Debug.Log("hit");
        }

    }
    private void Blocking(){
        // We need to be able to block move and we cannot be currently attacking
        if(CanBlock && CanMove && CanAttack){ 
            Debug.Log("deflect");
        }
    }
    private void GroundCheck(){

    }
}
