using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Idle : IEnemyState
{
    public void Enter(isEnemy enemy)
    {
        // Set the enemy's animation to idle
        //enemy.animator.SetBool("isIdle", true);
        
        Debug.Log("Enemy is now idle.");
    }
    public void Execute(isEnemy enemy)
    {
        Debug.Log("Enemy is executing idle state.");

        // Check if the player is within aggro range
        if (enemy.currentPlayerDistance < enemy.aggroRange)
        {
            enemy.ChangeState(new MovingToPlayer());
        }
    }
    public void Exit(isEnemy enemy)
    {
        Debug.Log("Enemy is exiting idle state.");
        // Reset the idle animation trigger
        //enemy.animator.SetBool("isIdle", false);
    }
}