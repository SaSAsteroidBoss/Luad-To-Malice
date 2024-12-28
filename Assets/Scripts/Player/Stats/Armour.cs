using UnityEngine;
using UnityEngine.Events;

public class Armour : MonoBehaviour
{
   private Stats _stats;

   private ItemInventory inventory;

   public UnityAction OnArmour;
   
   void Start()
   {
      _stats = GetComponent<Stats>();
      
      if (gameObject.CompareTag("Player"))
      {
         inventory = GetComponent<ItemInventory>();
      }
      
      OnArmour += HandleArmour;
   }
   private void Update()
   {
      
   }

   private void HandleArmour()
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
