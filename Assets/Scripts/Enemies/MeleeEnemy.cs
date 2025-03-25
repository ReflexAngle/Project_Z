using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestEnemy : isEnemy
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
