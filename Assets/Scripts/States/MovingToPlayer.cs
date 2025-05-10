using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingToPlayer : IEnemyState
{
    public void Enter(isEnemy enemy)
    {
        // Set the enemy's animation to move
        //enemy.animator.SetBool("isMoving", true);
        Debug.Log("Enemy is now moving towards the player.");
    }
    public void Execute(isEnemy enemy)
    {

        Debug.Log("Enemy is executing moving state.");

        // Move towards the player
        Vector3 direction = (enemy.player.transform.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * enemy.moveSpeed * Time.deltaTime;

        // Check if the player is within attack range
        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) < enemy.attackRange)
        {
            // If so, switch to the attacking state
            enemy.ChangeState(new Attacking());
        }
        else if (enemy.canMove == true)
        {

            enemy.player.transform.position = new Vector3(enemy.player.position.x, enemy.player.position.y, enemy.player.position.z);
            enemy.agent.SetDestination(enemy.player.position);

        }
    }
    public void Exit(isEnemy enemy)
    {
        // Reset the move animation trigger
        //enemy.animator.SetBool("isMoving", false);
    }
}