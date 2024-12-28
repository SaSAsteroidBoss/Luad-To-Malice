using UnityEngine;
using UnityEngine.UI;


public class HealthUI : MonoBehaviour
{
   private Stats _stats;
   private Slider healthSlider;
   
   void Start()
   {
      _stats = GetComponent<Stats>();
      
      healthSlider = transform.Find("Character UI").transform.Find("HP Bar").GetComponent<Slider>();
      healthSlider.maxValue = _stats.maxHp;
      healthSlider.minValue = 0;
   }

   void Update()
   {
      healthSlider.value = _stats.hp;
   }
   
   
}
