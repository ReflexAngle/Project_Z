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
        Debug.Log("Hit something");

        if (other.gameObject.TryGetComponent<isEnemy>(out isEnemy myenemy))
        {
            Debug.Log("Hit enemy");
            myenemy.TakeDamage(damage);

            myenemy.Die();
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
