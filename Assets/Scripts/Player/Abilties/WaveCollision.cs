using UnityEngine;

public class WaveCollision : MonoBehaviour
{

    public Damage damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {

            Debug.LogError(other.gameObject.name);
            damage.CalculatePlayerTotalDamage(other.gameObject);
        }

    }
}
