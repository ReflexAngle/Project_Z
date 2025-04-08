using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public abstract class isEnemy : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent agent;

    [SerializeField]
    public Transform player;

    [SerializeField]
    public IEnemyState currentState = new Idle();

    [SerializeField]
    public bool canMove = true;

    [SerializeField]
    public bool canAttack = true;

    [SerializeField]
    public float maxHealth;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    public float attackDamage;

    [SerializeField]
    public float attackSpeed;

    [SerializeField]
    public float attackRange;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public float aggroRange;

    public float currentPlayerDistance;

    [SerializeField]
    public string enemyTag = "Enemy";

    [SerializeField]
    public Animator animator;

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit(this);
        }
        currentState = newState;
        currentState.Enter(this);
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        currentState = new Idle();
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        agent.speed = moveSpeed;

        ChangeState(new Idle());

    }


    private void Update()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
        if (tag == null)
        {
            tag = enemyTag;
        }
        if (currentState == null)
        {
            ChangeState(new Idle());
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        GetPlayerDistance();

        currentState.Execute(this);
        
    }

    public void GetPlayerDistance()
    {
        currentPlayerDistance = Vector3.Distance(transform.position, player.position);

        if (currentPlayerDistance < aggroRange)
        {
            canMove = true;
            Debug.Log("Enemy is in aggro range.");
            ChangeState(new MovingToPlayer());
        }
        else
        {
            canMove = false;
            //Debug.Log("Enemy is out of aggro range.");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage! It has " + currentHealth + " / " + maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("enemy dies");
            Die();
        }
        else
        {
            Debug.Log("enemy survives");
        }
    }
    public IEnumerator Attack(PlayerStats target)
    {
        canAttack = false;
        Debug.Log("Enemy attacks player for " + attackDamage + " damage!");
        target.TakeDamage(attackDamage);
        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }

    public void Die()
    {
        GetComponentInParent<EnemyPool>().ReturnEnemy(gameObject);
        Debug.Log("Enemy died!");
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") & currentState == new Attacking())
        {
            Debug.Log("Enemy collided with Player Trigger!");
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player RB!");

            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }


}
