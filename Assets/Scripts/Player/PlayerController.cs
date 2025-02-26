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
    private bool isJumping = false;
    private bool isOnTheMove;
    private bool isOnGround;

    [SerializeField] private int lockVeritcalMove;
    [SerializeField] private float speed = 5f;

    private float gravity = 9.81f;
    [SerializeField] private float downwardForce = -20f;
    [SerializeField] private float jumpForce = 10f;
    private float jumpCutMultiplier = .5f;
    private int jumpBufferCount;
    private float groundCheckDistance = .6f; 

    private Vector2 moveDirection = Vector2.zero;
    [SerializeField] private Vector2 floorSize;
    private Vector3 velocity;
    [SerializeField] private LayerMask groundLayer;

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
    public bool IsJumping{
        get{return isJumping;}
        set{this.isJumping = value;}
    }
    public bool IsOnGround{ // handle the jump animations in here
        get{return isOnGround;}
        set{this.isOnGround = value;}
    }
    public bool IsOnTheMove{
        get{return isOnTheMove;}
        set{this.isOnTheMove = value;}
    }
    public int LockVeritcalMove{
        get{return lockVeritcalMove;}
        set{this.lockVeritcalMove = value;}
    }
    void Awake(){
        //navConstraint = GameEventManager.instance.NavMeshConstraint;
        navConstraint = GetComponent<NavMeshConstraint>();
        controller = GetComponent<CharacterController>();
        playerControlls = new InputControlls();

        playerControlls.Movement.Jump.started += ctx => StartJumping();
        playerControlls.Movement.Jump.canceled += ctx => EndJump();

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
        ApplyGravity();
        //Debug.Log(navConstraint);
    }
    
    // handles moveing along the plain wont allow the player to move off the plains nav mesh
    private void BasicMovement(){
        moveDirection = move.ReadValue<Vector2>();    

        Vector3 _move = new Vector3(moveDirection.x, 0, moveDirection.y); 
        controller.Move(_move * speed * Time.deltaTime);
        Vector3 desiredPosition = transform.position + _move * speed * Time.deltaTime;

       if (navConstraint != null && navConstraint.IsValidDestination(desiredPosition)){
        controller.Move(_move * speed * Time.deltaTime);
        }
    }
    private void StartJumping(){
        if(CanJump && controller.isGrounded){
            velocity.y = jumpForce;
            isJumping = true;
            jumpBufferCount = 0;
        }
        Debug.Log("jump");

    }
    private void EndJump(){
        if (isJumping && velocity.y > 0){ // Only reduce height if still moving up
            velocity.y *= jumpCutMultiplier;
        }
        isJumping = false;

    }
    // ques up the next jump to make it feel more fluid
    private void JumpBuffer(){

    }
    // use a ray cast with a distance of 5 away from the player
    // if the raycast hits an object with an enemy tag then it deals damage to them else it just misses
    private void Attacking(){
        RaycastHit weaponDistance;
        if(CanAttack && CanMove && CanBlock){
            if(Physics.Raycast(transform.position, Vector3.right, out weaponDistance)){
                Debug.Log("Enemy Hit");
            }else{
                Debug.Log("miss");
            }
        }
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
    // uses a raycast pointed down to check if the player is on the ground
    // private void GroundCheck(){ // checks to see if the player is on the ground with a raycast
    //      RaycastHit hit; 
    //      if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer)){
    //          isOnGround = true;
    //      }else{
    //          isOnGround = false;
    //      }
    // }  
    // applies a constant downward force on the player
    private void ApplyGravity(){ // gravity is constanly applied to the player
        if (controller.isGrounded){
            velocity.y = -2f;
            IsJumping = false;
            
        }else{
            velocity.y -= gravity * Time.deltaTime;
            velocity.y = Mathf.Max(velocity.y, downwardForce); // clamps the fall speed
        }
        controller.Move(velocity * Time.deltaTime);   
    } 
}
