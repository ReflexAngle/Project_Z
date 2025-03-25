using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class isEnemy : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent agent;

    public Transform player;

    public bool canMove = true;

    public float maxHealth;

    public float currentHealth;

    public float attackDamage;

    public float attackSpeed;

    public float moveSpeed;

    public string enemyTag = "Enemy";

    public StateMachineBehaviour currentState;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        this.AddComponent<NavMeshAgent>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        agent.speed = moveSpeed;
    }

    private void Update()
    {
        if (canMove == true)
        {
            Debug.Log("Moving to player");

            player.transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
            agent.SetDestination(player.position);

        }
    }

    public void Attack(PlayerStats target)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        target.TakeDamage(attackDamage);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


}
