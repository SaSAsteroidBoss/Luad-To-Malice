using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Damage : MonoBehaviour
{
    public float baseDamage;

    public float totalDamage;

    public DamageSource [] damageSources;


    public void AddDamageSource(DamageObject item)
    {
        for (var i = 0; i < damageSources.Length; i++)
        {
            if (damageSources[i].item == item && damageSources[i].damageSourceName == item.name)
            {
                damageSources[i].amount++;
                 
                Debug.Log("Object Already Add");

                break;

            }
            else if (damageSources[i].item == null && damageSources[i].damageSourceName == string.Empty)
            {
                 damageSources[i].item = item;
                 damageSources[i].damageSourceName = item.itemName;
                 damageSources[i].mainDamage = item.mainDamage;
                 damageSources[i].statusEffectDamage = item.statusEffectDamage;
                 damageSources[i].amount = 1;
                 
                 Debug.Log("Object Not Add");
                 
                break;

            }

        }
    }
    
    
    public void CalculatePlayerTotalDamage(GameObject target)
    {
        Debug.LogError(target.name);
        
        if (damageSources[0].damageSourceName == "")
        {
            totalDamage = baseDamage;
            target.GetComponent<Health>().TakeDamage(totalDamage);
        }
        
        for (var i = 0; i < damageSources.Length; i++)
        {
            if (damageSources[i].damageSourceName == "Electric Boogaloo")
            {   
                float mainDamagePercent = 100 / (damageSources[i].mainDamage * damageSources[i].amount);
                float damagePercentOfBase = baseDamage / mainDamagePercent;
                
                
                float statusEffectDamagePercent = 100 / (damageSources[i].statusEffectDamage * damageSources[i].amount);
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



[Serializable]
public struct DamageSource
{
    public DamageObject item;
    
    public string damageSourceName;
    
    public float mainDamage;
    
    public float statusEffectDamage;
    
    public int amount;
}
