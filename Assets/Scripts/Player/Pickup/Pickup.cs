using UnityEngine;


public class Pickup : MonoBehaviour
{
     [SerializeField]
     private Item _item;

     public Item heldItem{get;set;}

     public void Start()
     {
          heldItem = _item;
     }
}
