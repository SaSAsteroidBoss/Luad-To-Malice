using UnityEngine;

public class meleeHitBoxPrefab : MonoBehaviour
{
    private Stats _stats;

    public void Setup(Stats localStats)
    {
        _stats = localStats;
    }
    
    private void Start()
    {
       // transform.parent = null;
        Destroy(gameObject, 0.4f);
    }


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
       if (other.gameObject.CompareTag("Player"))
        {
            print(other.name);
            print("trigger enter Melee");
            var playerDam = other.gameObject.GetComponent<PlayerDamage>();
            playerDam.Damage(_stats.damage);
           // other.gameObject.GetComponent<PlayerDamage>().Damage(_stats.damage);
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
           //Destroy(gameObject);
        }

    }

}

