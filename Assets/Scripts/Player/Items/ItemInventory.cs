using System;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public ItemSlot[] itemSlots;
    
    
    public void AddItem(ItemObject item)
     {
         for (var i = 0; i < itemSlots.Length; i++)
         {
             if (itemSlots[i].item == item && item.name == itemSlots[i].name)
             {
                 itemSlots[i].amount++;
                 
                 break;

             }
             else if (itemSlots[i].name == string.Empty && item.name != itemSlots[i].name)
             {
                 var itemData = new ItemSlotData
                 {
                     primaryValue = item.primaryValue,
                     secondaryValue = item.secondaryValue
                 };

                 itemSlots[i].item = item;
                 itemSlots[i].name = item.name;
                 itemSlots[i].itemData = itemData;
                 itemSlots[i].amount = 1;
                 
                 break;

             }

         }
     }
}


[Serializable]

public struct ItemSlot
{
    public string name;
    public ItemObject item;
    public ItemSlotData itemData;
    public int amount;
}


