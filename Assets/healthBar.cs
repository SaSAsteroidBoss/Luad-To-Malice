using UnityEngine;
using UnityEngine.UI;


public class healthBar : MonoBehaviour
{
   [SerializeField]
   private Slider healthSlider;
   
   
   private Health health;

   void Start()
   {
      health = GetComponent<Health>();
      //healthSlider.value = health.currentHealth / health.maxHealth;
   }

   void Update()
   {
      healthSlider.value = health.currentHealth / health.maxHealth;
   }
   
   
}
