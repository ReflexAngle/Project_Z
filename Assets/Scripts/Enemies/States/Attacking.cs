using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Attacking : IEnemyState
{
    public void Enter(isEnemy enemy)
    {
        // Set the enemy's animation to attack
        //enemy.animator.SetTrigger("Attack");
        Debug.Log("Enemy is now attacking.");
    }
    public void Execute(isEnemy enemy)
    {
        Debug.Log("Enemy is executing attack state.");
        // Check if the enemy is still in range of the player
        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) > enemy.attackRange)
        {
            // If not, switch to the idle state
            enemy.ChangeState(new MovingToPlayer());


        }
        else
        {
            // If the player is still in range, attack the player
            PlayerStats target = enemy.player.GetComponent<PlayerStats>();
            if (target != null)
            {
                enemy.Attack(target);
            }
        }
    }


    public void Exit(isEnemy enemy)
    {
        Debug.Log("Enemy is exiting attack state.");
        // Reset the attack animation trigger
        //enemy.animator.ResetTrigger("Attack");
    }
    
    
}

