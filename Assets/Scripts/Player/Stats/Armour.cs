using UnityEngine;
using UnityEngine.Serialization;

public class Armour : MonoBehaviour
{
   public int armour;
   
   [FormerlySerializedAs("_healthSource")] [SerializeField]
   private ItemValueSourceData [] _armourSource;
   
   
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
