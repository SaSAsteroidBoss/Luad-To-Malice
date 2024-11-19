using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private IEnumerator _heal;
    
    public float currentHealth;

    public float maxHealth;

    public float healAmount;

    public ItemValueSourceData [] healthSource;
    
    [SerializeField] private List<Transform> spawnTransforms = new List<Transform>();

    private Enemy_Ranged_Detect detection;
    public void Start()
    {
        currentHealth = maxHealth;

        if(gameObject.CompareTag("Enemy"))
        {
            detection = GetComponentInChildren<Enemy_Ranged_Detect>();
        }
        //enemiesPooledObject = EnemyObjectPool.
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void TakeDamage(float damage)
    {
        var healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (_heal == null)
        {
            //_heal = Heal();
            //StartCoroutine(_heal);
        }

        if (currentHealth == 0)
        {
            if(gameObject.CompareTag("Enemy"))
                detection.ResetDetection(gameObject);
                
            gameObject.SetActive(false);
            //Destroy(gameObject);
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

    
    public void AddHealthSource(HealthObject item)
    {
        for (var i = 0; i < healthSource.Length; i++)
        {
            if (healthSource[i].item == item && healthSource[i].sourceName == item.name)
            {
                healthSource[i].amount++;
                 
                Debug.Log("Object Already Add");

                break;

            }
            else if (healthSource[i].item == null && healthSource[i].sourceName == string.Empty)
            {
                healthSource[i].item = item;
                healthSource[i].sourceName = item.itemName;
                healthSource[i].primaryValue = item.mainHealthIncrease;
                healthSource[i].amount = 1;
                 
                Debug.Log("Object Not Add");
                 
                break;

            }

        }
    }
}

[Serializable]
public struct HealingSource
{
    public Health item;
    
    public string healingSourceName;

    public float mainHealAmount;
    
    public int amount;
}
