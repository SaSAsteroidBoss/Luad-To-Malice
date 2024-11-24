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
               Destroy(gameObject);
          }
     }
}
