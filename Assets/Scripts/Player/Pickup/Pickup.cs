using System;
using Unity.VisualScripting;
using UnityEngine;


public class Pickup : MonoBehaviour
{
     [SerializeField]
     private ItemObject _item;
     

     private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("Player"))
          {
               other.GetComponent<ItemInventory>().AddItem(_item);

               switch (_item.name)
               {
                       
                    case "Banage":
                         ItemObjectPool.Instance.AddBanagePooledObject(gameObject);
                         break;   
                    
                    case "Electric Boogaloo":
                         ItemObjectPool.Instance.AddElectricBoogalooPooledObject(gameObject);
                         break;    
                    
                    case "Gel Layer":
                         ItemObjectPool.Instance.AddGelLayerPooledObject(gameObject);
                         break;    
                    
                    case "Soldier Biotics":
                         ItemObjectPool.Instance.AddSoldierBioticsPooledObject(gameObject);
                         break;   
                 
                    
                    
               }
          }
     }
}
