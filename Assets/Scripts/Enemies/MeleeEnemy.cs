using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : isEnemy
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


}
