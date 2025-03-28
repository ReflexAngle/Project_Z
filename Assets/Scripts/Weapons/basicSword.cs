using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicSword : Weapon
{
    [SerializeField]
    public GameObject prefab;

    [SerializeField]
    public override string WeaponName => "Basic Sword";
    [SerializeField]
    public override float Damage => 30;
    [SerializeField]
    public override float Knockback => 1000;
    [SerializeField]
    public override float AttackSpeed => 1;

    public override void Attack()
    {
        // Implement attack logic here
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
