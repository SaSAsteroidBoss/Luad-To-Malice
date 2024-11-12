using UnityEngine;

public class blastCollision : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyDamage>().CalculateTotalEnemeyDamage(other.gameObject, damage);
        }
    }
}
