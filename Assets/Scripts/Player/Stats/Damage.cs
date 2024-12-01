using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Damage
{ 
    public abstract void CalculateDamage(GameObject dmgTarget);
    
    public abstract void CalculateAeoDamage(GameObject dmgTarget);
    
}

public class BossDamage : Damage 
{
    private readonly float _baseDamage;
    private readonly float _aeoDamage;
    private float _totalDamage;

    public BossDamage(float baseDamage, float aoeDamage)
    {
        _baseDamage = baseDamage;
        _aeoDamage = aoeDamage;
    }

    public override void CalculateDamage(GameObject dmgTarget)
    {
        _totalDamage = _baseDamage - dmgTarget.GetComponent<Armour>().armour;
        dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
    }

    public override void CalculateAeoDamage(GameObject dmgTarget)
    {
        _totalDamage =_aeoDamage - dmgTarget.GetComponent<Armour>().armour;
        dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
    }
}

public class MeleeEnemyDamage
{
    
}

public class RangeEnemyDamage: Damage 
{
    private readonly float _baseDamage;
    private readonly float _aeoDamage;
    private float _totalDamage;

    public RangeEnemyDamage (float baseDamage, float aoeDamage)
    {
        _baseDamage = baseDamage;
        _aeoDamage = aoeDamage;
    }

    public override void CalculateDamage(GameObject dmgTarget)
    {
        _totalDamage = _baseDamage - dmgTarget.GetComponent<Armour>().armour;
        dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
    }

    public override void CalculateAeoDamage(GameObject dmgTarget)
    {
        //_totalDamage =_aeoDamage - dmgTarget.GetComponent<Armour>().armour;
        //dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
    }
}

public class PlayerDamage : Damage
{
    private readonly List<ItemValueSourceData> _damageSources;
    
    private readonly float _baseDamage;
    private readonly float _aeoDamage;
    private float _totalDamage;
   
    public PlayerDamage(float baseDamage, float aoeDamage)
    {
        _baseDamage = baseDamage;
        _aeoDamage = aoeDamage;
        
        var sourceDataOne = new ItemValueSourceData();
        var sourceDataOTwo = new ItemValueSourceData();
        
        _damageSources = new List<ItemValueSourceData> { sourceDataOne, sourceDataOTwo };
    }

    
    public override void CalculateDamage(GameObject dmgTarget)
    {
        if (_damageSources[0].sourceName == null)
        {
            _totalDamage = _baseDamage - dmgTarget.GetComponent<Armour>().armour;
            dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
        }
        
        for (var i = 0; i < _damageSources.Count; i++)
        {
            if (_damageSources[i].sourceName == "Electric Boogaloo")
            {
                float mainDamagePercent = 100 / (_damageSources[i].primaryValue * _damageSources[i].amount);
                float damagePercentOfBase = _baseDamage / mainDamagePercent;


                float statusEffectDamagePercent = 100 / (_damageSources[i].secondaryValue * _damageSources[i].amount);
                float targetMaxHealth = dmgTarget.GetComponent<Health>().maxHealth;
                float damagePercentOfMaxHeath = targetMaxHealth / statusEffectDamagePercent;

                _totalDamage = _baseDamage + damagePercentOfBase + damagePercentOfMaxHeath  - dmgTarget.GetComponent<Armour>().armour;
                dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
            }
        }
    }
    
    public override void CalculateAeoDamage(GameObject dmgTarget)
    {
        
    }

    public void AddDamageSource(DamageObject item)
    {
        for (var i = 0; i < _damageSources.Count; i++)
        {
            if (_damageSources[i].item == item && _damageSources[i].sourceName == item.name)
            {
                Debug.Log("Increase Damage Source Amount" +  " "  + _damageSources[i] +  " "  +_damageSources[i].sourceName);
                _damageSources[i].amount++;
                break;
            }
            
            if (_damageSources[i].item == null)
            {
                _damageSources[i].item = item;
                _damageSources[i].sourceName = item.itemName;
                _damageSources[i].primaryValue = item.mainDamage;
                _damageSources[i].secondaryValue = item.statusEffectDamage;
                _damageSources[i].amount = 1;
                
                Debug.Log("Add New Damage Source" +  " "  + _damageSources[i] +  " "  +_damageSources[i].sourceName);
               
                break;
            }
        }
    }
}


