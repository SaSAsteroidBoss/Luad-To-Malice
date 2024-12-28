using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamage
{
    private Stats _stats;
    
    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    public void Damage(float damage)
    {
        var dmgHp = damage - _stats.armour;
        _stats.OnDecreaseHp?.Invoke(dmgHp);
    }
}
