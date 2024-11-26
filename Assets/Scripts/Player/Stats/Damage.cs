using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Damage : MonoBehaviour
{
    public float baseDamage;

    public float totalDamage;
   
    [SerializeField]
    private ItemValueSourceData [] _damageSources;

    void Start()
    {   
        
    }
    public void AddDamageSource(DamageObject item)
    {
        Debug.LogWarning("damage source added");
        for (var i = 0; i < _damageSources.Length; i++)
        {
            if (_damageSources[i].item == item && _damageSources[i].sourceName == item.name)
            {
                _damageSources[i].amount++;
                 
                Debug.Log("Object Already Add");

                break;

            }
            else if (_damageSources[i].item == null && _damageSources[i].sourceName == string.Empty)
            {
                 _damageSources[i].item = item;
                 _damageSources[i].sourceName = item.itemName;
                 _damageSources[i].primaryValue = item.mainDamage;
                 _damageSources[i].secondaryValue = item.statusEffectDamage;
                 _damageSources[i].amount = 1;
                 
                 Debug.Log("Object Not Add");
                 
                break;

            }

        }
    }
    
    
    public void CalculatePlayerTotalDamage(GameObject target)
    {
        print(_damageSources.Length +" Damage source");
        if (_damageSources[0].sourceName == "")
        {
            print("Damage source is empty");
            totalDamage = baseDamage;
            target.GetComponent<Health>().TakeDamage(totalDamage);
        }
        
        for (var i = 0; i < _damageSources.Length; i++)
        {
            if (_damageSources[i].sourceName == "Electric Boogaloo")
            {   
                float mainDamagePercent = 100 / (_damageSources[i].primaryValue * _damageSources[i].amount);
                float damagePercentOfBase = baseDamage / mainDamagePercent;
                
                
                float statusEffectDamagePercent = 100 / (_damageSources[i].secondaryValue * _damageSources[i].amount);
                float targetMaxHealth = target.GetComponent<Health>().maxHealth;
                float damagePercentOfMaxHeath = targetMaxHealth / statusEffectDamagePercent;
                
                totalDamage = baseDamage + damagePercentOfBase + damagePercentOfMaxHeath; 
                
                target.GetComponent<Health>().TakeDamage(totalDamage);
            }
        }
    }

    public void CalculateEnemyTotalDamage(GameObject target)
    {
        totalDamage = baseDamage - target.GetComponent<Armour>().armour;
        target.GetComponent<Health>().TakeDamage(totalDamage);
    }
}
