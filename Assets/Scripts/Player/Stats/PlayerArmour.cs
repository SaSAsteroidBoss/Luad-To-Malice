using UnityEngine;
using UnityEngine.Events;

public class PlayerArmour : MonoBehaviour, IArmour
{
    private Stats _stats;

    private ItemInventory inventory;

    public UnityAction OnArmour;
   
    void Start()
    {
        _stats = GetComponent<Stats>();
      
        inventory = GetComponent<ItemInventory>();
        
        OnArmour += HandleArmour;
    }
    
    public void HandleArmour()
    {
        for (var i = 0; i < inventory.itemSlots.Length; i++)
        {
            if (inventory.itemSlots[i].name == "Gel Layer")
            {
                _stats.OnIncreaseArmour?.Invoke(inventory.itemSlots[i].itemData.primaryValue);
            }
        }
    }
}
