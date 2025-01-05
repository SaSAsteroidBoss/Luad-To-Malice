using System.Globalization;
using TMPro;
using UnityEngine;


public class ArmourUIBoss : MonoBehaviour
{
   private Stats _stats;
   private TMP_Text armourTextBox;

   void Start()
   {
      _stats = GetComponent<Stats>();
      armourTextBox = transform.Find("Character UI").transform.Find("Armour Panel").GetComponentInChildren<TMP_Text>();
   }

   void Update()
   {
      armourTextBox.text = _stats.armour.ToString(CultureInfo.CurrentCulture);
   }

}
