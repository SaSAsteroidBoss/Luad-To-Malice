using System.Globalization;
using TMPro;
using UnityEngine;


public class ArmourUI : MonoBehaviour
{
   private Armour armour;
   private TMP_Text armourTextBox;

   void Start()
   {
      armour = GetComponent<Armour>();
      //_stats = GetComponent<Stats>();
      armourTextBox = transform.Find("Character UI").transform.Find("Armour Panel").GetComponentInChildren<TMP_Text>();
   }

   void Update()
   {
      //armourTextBox.text = armour.
   }

}
