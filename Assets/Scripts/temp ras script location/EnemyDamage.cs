using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour, IDamage
{
    private Stats _stats;

    public UnityAction<ItemInventory> UpdateInventory;
    
    private ItemInventory inventory;
    
    private void Start()
    {
        _stats = GetComponent<Stats>();
        UpdateInventory += SetInventory;
    }

    public void Damage(float damage)
    {
        for (var i = 0; i < inventory.itemSlots.Length; i++)
        {
            if (inventory.itemSlots[i].name != "Electric Boogaloo")
            {
                _stats.UpdateHp?.Invoke(damage - _stats.armour);
            }
            
            if (inventory.itemSlots[i].name == "Electric Boogaloo")
            {
                float primaryDamagePercent = 100 / (inventory.itemSlots[i].itemData.primaryValue * inventory.itemSlots[i].amount);
                float damagePercentOfDamage = damage / primaryDamagePercent;

                float secondaryDamagePercent = 100 / (inventory.itemSlots[i].itemData.secondaryValue * inventory.itemSlots[i].amount);
                float targetMaxHealth = _stats.maxHp;
                float damagePercentOfMaxHeath = targetMaxHealth / secondaryDamagePercent;

                _stats.UpdateHp?.Invoke(damage + damagePercentOfDamage + damagePercentOfMaxHeath - _stats.armour);
            }
        }
        
        
        _stats.UpdateHp?.Invoke(damage - _stats.armour);
        
        
    }

    private void SetInventory(ItemInventory localInventory)
    {
        if (localInventory != null)
        {
            inventory = localInventory;
        }
    }
}
