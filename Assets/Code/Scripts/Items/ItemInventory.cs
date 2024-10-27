using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public ItemSlot[] itemSlots;


     public void AddItem(Item item)
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
                 itemSlots[i].amount = 1;

                 switch (item.type)
                 {
                     case ItemType.Damage:
                        
                         break;
                   
                     case ItemType.StatusEffect: 
                         
                         break;
                     
                     case ItemType.Healing:
                        
                         this.GetComponent<Health>().AddHealAmount(item.itemEffectAmount);
                         
                         break;
                   
                     case ItemType.Health:
                       
                         break;
                   
                     case ItemType.Armour:
                        
                         break;
                  
                     case ItemType.MovementSpeed:
                         
                         break;
                     
                     case ItemType.AttackSped:
                         
                         break;
                     
                     default:
                         throw new ArgumentOutOfRangeException();
                 }
                 
                 Debug.Log("Object Not Add");

                 break;

             }

         }
     }
}

[Serializable]

public struct ItemSlot
{
    public string name;
    public Item item;
    public int amount;
}

