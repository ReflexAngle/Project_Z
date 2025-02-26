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
    public float healthRegen;

    public float maxStamina;
    public float currentStamina;
    public float staminaRegen;

    public float maxMagic;
    public float currentMagic;
    public float magicRegen;

    public void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentMagic = maxMagic;
    }
    public void Update()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += Time.deltaTime + staminaRegen;
        }
        if (currentMagic < maxMagic)
        {
            currentMagic += Time.deltaTime * magicRegen;
        }
        if (currentHealth < maxHealth)
        {
            currentHealth += Time.deltaTime * healthRegen;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void UseMana(float amount)
    {
        currentMagic -= amount;
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
