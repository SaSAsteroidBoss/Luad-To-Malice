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

    [SerializeField]
    private ItemValueSourceData [] _healthSource;
  
    [SerializeField]
    private ItemValueSourceData [] _healingSource;
    
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

        if (_heal == null && gameObject.CompareTag("Player"))
        {
            _heal = Heal();
            StartCoroutine(_heal);
        }

        if (currentHealth == 0)
        {
            if(gameObject.CompareTag("Enemy"))
                detection.ResetDetection(gameObject);   
                
            gameObject.SetActive(false);
        }
    }

    public void AddHealAmount(float increaseHealAmount)
    {
        healAmount += increaseHealAmount;
    }
    
    public void AddHealthAmount(float increaseHealthAmount)
    {
        maxHealth += increaseHealthAmount;
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

            if (currentHealth >= maxHealth)
            {
                Debug.Log("Heal has reached max health");
                currentHealth = maxHealth;
                StopCoroutine(_heal);
                _heal = null;
            }
          
        }
    }

    
    public void AddHealthSource(HealthObject item)
    {
        for (var i = 0; i < _healthSource.Length; i++)
        {
            if (_healthSource[i].item == item && _healthSource[i].sourceName == item.name)
            {
                _healthSource[i].amount++;
                CalculatePlayerTotalHealth();
                
                Debug.Log("Object Already Add");

                break;

            }
            else if (_healthSource[i].item == null && _healthSource[i].sourceName == string.Empty)
            {
                _healthSource[i].item = item;
                _healthSource[i].sourceName = item.itemName;
                _healthSource[i].primaryValue = item.mainHealthIncrease;
                _healthSource[i].amount = 1;

                CalculatePlayerTotalHealth();
                
                Debug.Log("Object Not Add");
                 
                break;

            }

        }
    }

    public void AddHealSource(HealingObject item)
    {
        for (var i = 0; i < _healingSource.Length; i++)
        {
            if (_healingSource[i].item == item && _healingSource[i].sourceName == item.name)
            {
                _healingSource[i].amount++;
                CalculatePlayerTotalHealing();
                
                Debug.Log("Object Already Add");

                break;

            }
            else if (_healingSource[i].item == null && _healingSource[i].sourceName == string.Empty)
            {
                _healingSource[i].item = item;
                _healingSource[i].sourceName = item.itemName;
                _healingSource[i].primaryValue = item.mainHealValue;
                _healingSource[i].amount = 1;
                CalculatePlayerTotalHealing();
                 
                Debug.Log("Object Not Add");
                 
                break;

            }

        }
    }
    
    public void CalculatePlayerTotalHealing()
    {
     
        for (var i = 0; i <_healingSource.Length; i++)
        {
            if (_healingSource[i].sourceName == "Banage")
            {   
                float healValue = _healingSource[i].primaryValue * _healingSource[i].amount;
                AddHealAmount(healValue);
            }
        }
    }
    
    void CalculatePlayerTotalHealth()
    {
        for (var i = 0; i <_healthSource.Length; i++)
        {
            if (_healthSource[i].sourceName == "Soldier Biotics")
            {   
                AddHealthAmount(_healthSource[i].primaryValue);
            }
        }
    }
}