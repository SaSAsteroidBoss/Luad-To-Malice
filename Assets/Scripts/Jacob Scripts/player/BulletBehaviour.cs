using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float speed;
    
    private Stats _stats;

    public void Setup(Stats localStats)
    {
        _stats = localStats;
    }
    

    private void Start()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            other.gameObject.GetComponent<PlayerDamage>().Damage(_stats.damage);
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
    }
}
