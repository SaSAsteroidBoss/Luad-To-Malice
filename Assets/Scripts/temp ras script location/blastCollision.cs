using UnityEngine;

public class blastCollision : MonoBehaviour
{
    //public float damage;

    private PlayerDamage _target;

    public void SetDamageScript(PlayerDamage newTarget)
    {
        _target = newTarget;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")&& other.gameObject != null )
        {
            //_target.CalculateDamage(other.gameObject);
        }
    }
}
