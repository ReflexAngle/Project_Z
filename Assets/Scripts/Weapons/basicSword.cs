using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : Weapon
{
    [SerializeField]
    public GameObject prefab;
    public override void Attack()
    {

    }

    public BasicSword()
    {
        weaponName = "basicSword";
        damage = 20;
        attackSpeed = 1.0f;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            isEnemy myenemy = other.gameObject.GetComponent<isEnemy>();
            Debug.Log("Hit enemy " + myenemy.name);

            myenemy.TakeDamage(damage);

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 collisionDirection = (other.transform.position - transform.position).normalized;
                rb.AddForce(collisionDirection * 1000, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("No rigidbody found on enemy");
            }

        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
