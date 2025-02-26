using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class isEnemy : MonoBehaviour
{
    [SerializeField]
    public float maxHealth;

    public float currentHealth;

    public float attackDamage;

    public float attackSpeed;

    public float moveSpeed;

    public string enemyTag = "Enemy";

    public StateMachineBehaviour currentState;

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

    protected virtual void Start()
    {
        gameObject.tag = enemyTag;
        currentHealth = maxHealth;
    }
}
