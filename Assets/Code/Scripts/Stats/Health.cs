using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private IEnumerator _heal;
    
    public float currentHealth;
 
    public float maxHealth = 100f;

    public float healAmount = 5;
    
    public void Start()
    {
        currentHealth = maxHealth;
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void TakeDamage(float damage)
    {
        var healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (_heal == null)
        {
            _heal = Heal();
            StartCoroutine(_heal);
        }

       

    }

    public void AddHealAmount(float increaseHealAmount)
    {
        healAmount += increaseHealAmount;
    }

    private IEnumerator Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (currentHealth < maxHealth)
            { 
                Debug.Log("Heal has enough health");
                var healHealth = (healAmount / maxHealth) * 100;
                currentHealth += healHealth;
            }

            if (!(currentHealth >= maxHealth)) continue;
            Debug.Log("Heal has reached max health");
            currentHealth = maxHealth;
            StopCoroutine(_heal);
            _heal = null;
        }
    }

}
