using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    public void CalculateTotalEnemeyDamage(GameObject target, float damage)
    {
        if (health.currentHealth - damage <= 0)
        {
           
              //  gameObject.SetActive(false);
            Destroy(gameObject);   
           
        }
        else
        {
            health.TakeDamage(damage);
        }
        
    }

}
