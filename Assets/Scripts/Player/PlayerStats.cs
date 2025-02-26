using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// contains health, stamina, magic, etc. 
public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public float maxHealth;
    public float currentHealth;

    public float maxStamina;
    public float currentStamina;

    public float maxMagic;
    public float currentMagic;

    public void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentMagic = maxMagic;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
