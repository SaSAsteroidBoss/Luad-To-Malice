using UnityEngine;
using UnityEngine.UI;


public class HealthUIBoss : MonoBehaviour
{
   
   private Slider healthSlider;
   private float maxHp;
   private Health health;
   
   void Start()
   {
   
health = GetComponent<Health>();
      maxHp = health.maxHealth;
      
      healthSlider = transform.Find("Character UI").transform.Find("HP Bar").GetComponent<Slider>();
      healthSlider.maxValue =  maxHp;
      healthSlider.minValue = 0;
   
   }

   void Update()
   {
      if(health != null)
         healthSlider.value = health.currentHealth;
      //healthSlider.value = currentHp;
   }
   
   
}
