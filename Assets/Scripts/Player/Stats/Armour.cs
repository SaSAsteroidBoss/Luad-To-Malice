using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Armour : MonoBehaviour
{
   public int armour;
   
   private ItemSlotData [] _armourSource;

   private float timeIntival = 0;
   private float gap = 20; // in seconds

   void Start()
   {
      if (gameObject.name == "RangedEnemy")
      {
         float timeElapsed = Time.time / gap;
         for (int i = 0; i < timeElapsed; i++)
         {
            AddArmourAmount(1);
         }
      }
      timeIntival = Time.time + gap;
   }
   private void Update()
   {
      
      if (gameObject.name == "RangedEnemy")
      {
         if (Time.time >= timeIntival)
         {
            print("add Armour");
            AddArmourAmount(1f);
            timeIntival = Time.time + gap;
         }
      }
   }

   public void AddArmourAmount(float increaseArmourAmount)
   {
      armour += (int)increaseArmourAmount;
   }
   public void AddArmourSource(ArmourObject item)
   {
      for (var i = 0; i < _armourSource.Length; i++)
      {
         if (_armourSource[i].item == item && _armourSource[i].sourceName == item.name)
         {
            _armourSource[i].amount++;
            CalculatePlayerTotalArmour();
                
            Debug.Log("Object Already Add");

            break;

         }
         else if (_armourSource[i].item == null && _armourSource[i].sourceName == string.Empty)
         {
            _armourSource[i].item = item;
            _armourSource[i].sourceName = item.itemName;
            _armourSource[i].primaryValue = item.mainArmour;
            _armourSource[i].amount = 1;

            CalculatePlayerTotalArmour();
                
            Debug.Log("Object Not Add");
                 
            break;

         }
      }
   }
   
   void CalculatePlayerTotalArmour()
   {
      for (var i = 0; i <_armourSource.Length; i++)
      {
         if (_armourSource[i].sourceName == "Gel Layer")
         {   
            AddArmourAmount(_armourSource[i].primaryValue);
         }
      }
   }
}
