using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSword : Weapon
{
    [SerializeField]
    public GameObject prefab;

    public override string WeaponName => "Big Sword";
    public override float Damage => 70;
    public override float Knockback => 2000;
    public override float AttackSpeed => 0.5f;

    public override void Attack()
    {
        // Implement attack logic here
    }

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

    void Start()
    {
        // Initialization logic here
    }

    void Update()
    {
        // Update logic here
    }
}
