using System;
using System.Collections;
using System.Collections.Generic;
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
                 
                 Debug.Log("Object Already Add");

                 break;

             }
             else if (itemSlots[i].name == string.Empty && item.name != itemSlots[i].name)
             {
                 itemSlots[i].item = item;
                 itemSlots[i].name = item.name;
                 item.AddItemSource(this.gameObject);
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
    public int amount;
}


