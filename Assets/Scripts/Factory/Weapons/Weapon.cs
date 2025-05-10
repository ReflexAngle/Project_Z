using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : MonoBehaviour
{
    public abstract string WeaponName { get; }
    public abstract float Damage { get; }
    public abstract float Knockback { get; }
    public abstract float AttackSpeed { get; }
    public abstract void Attack();

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            isEnemy myenemy = other.gameObject.GetComponent<isEnemy>();
            Debug.Log("Hit enemy " + myenemy.name);

            myenemy.TakeDamage(Damage);

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 collisionDirection = (other.transform.position - transform.position).normalized;
                rb.AddForce(collisionDirection * Knockback);
            }
            else
            {
                Debug.Log("No rigidbody found on enemy");
            }

        }
    }
}
