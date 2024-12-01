using UnityEngine;

public class blastCollision : MonoBehaviour
{
    //public float damage;

    private Damage _target;

    public void SetDamageScript(Damage newTarget)
    {
        _target = newTarget;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
          //  other.GetComponent<EnemyDamage>().CalculateTotalEnemeyDamage(other.gameObject, damage);
          //_target.CalculateEnemyTotalDamage(other.gameObject);
            
        }
    }
}
