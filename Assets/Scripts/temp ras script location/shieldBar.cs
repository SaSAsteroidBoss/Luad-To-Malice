using TMPro;
using UnityEngine;


public class shieldBar : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI armourText;
   
   private Armour armour;

   void Start()
   {
      armour = GetComponent<Armour>();
   }

   void Update()
   {
      armourText.text = armour.armour.ToString();
   }

}
