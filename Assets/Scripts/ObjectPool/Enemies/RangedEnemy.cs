using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedEnemy : isEnemy
{
    public new void Attack(PlayerStats target)
    {
        if (target != null)
        {
            target.TakeDamage(attackDamage);
            Debug.Log("Enemy attacked the player for " + attackDamage + " damage!");

        }
        else
        {
            Debug.Log("Player not found!");
        }
    }
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Enemy collided with Player Trigger!");
    //        other.gameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
    //    }
    //}


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Enemy collided with Player RB!");

    //        collision.gameObject.GetComponent<PlayerStats>().TakeDamage(attackDamage);
    //    }
    //}


}
