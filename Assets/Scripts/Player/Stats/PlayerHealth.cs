using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private Stats _stats;
    
    private ItemInventory inventory;
    
    private float Hp
    {
        get => _stats.hp;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            Hp = value;
        }
    }

    private float MaxHp
    {
        get => _stats.maxHp;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            MaxHp = value;
        }
    }
    
    private double lastHitInterval;

    private const float HitInterval = 0.5F;

    public UnityAction OnHealth;
    public UnityAction OnHeal;
    public UnityAction OnDamage;
    
    public UnityAction<float> OnHealed;
 
    private UnityAction _onDie;
    
    private void Start()
    {
        _stats = GetComponent<Stats>();
        inventory = GetComponent<ItemInventory>();
        
        OnHealth += HandleHealth;
        OnDamage += HandleDamage;
        OnHeal += HandleHeal;
        _onDie += HandleDeath;
    }
    
    
    private void Update()
    {
        if (Hp < MaxHp)
        {
            var timeNow = Time.time;
            
            if (timeNow > lastHitInterval + HitInterval)
            {
                _stats.OnHealing?.Invoke(_stats.hpRegen);
                
                lastHitInterval = timeNow;
            }
        }
        
        if (Hp <= 0)
        {
            _onDie?.Invoke();
        }
    }
    
  
    private void HandleHealth()
    {
        for (var i = 0; i < inventory.itemSlots.Length; i++)
        {
            if (inventory.itemSlots[i].name == "Soldier Biotics")
            {
                _stats.OnIncreaseHealth?.Invoke(inventory.itemSlots[i].itemData.primaryValue);
            }
        }
    }
    
    private void HandleHeal()
    {
        for (var i = 0; i < inventory.itemSlots.Length; i++)
        {
            if (inventory.itemSlots[i].name == "Banage")
            {
                _stats.OnIncreaseHeal.Invoke(inventory.itemSlots[i].itemData.primaryValue);
            }
        }
    }
    
    public void HandleDamage()
    {
        lastHitInterval = Time.time;
    }
    
    public void HandleDeath()
    {
        Destroy(gameObject);
    }
    
}
