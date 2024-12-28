using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Ranged_Attack : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public float fireRate;
    private float fireRateTimer = 0;

    public float attackRange;

    [Header("Basic Attack")]
    [SerializeField] private float basicDamage;

    [Header("AOE Attack")]
    [SerializeField] private float areaDamage;
    
    private void Start()
    {
        fireRateTimer = fireRate;
    }

    private void Update()
    {
        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
        if (GetComponent<Enemy_Ranged_Seek>().target)
        {
            if (fireRateTimer <= 0 && Vector2.Distance(transform.position, GetComponent<Enemy_Ranged_Seek>().target.transform.position) <= attackRange)
            {
                //print("Firing Player Projectile");
                Vector3 diff = GetComponent<Enemy_Ranged_Seek>().target.transform.position - transform.position;
                diff.Normalize();
                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                
               var bullet =  Instantiate(bulletPrefab, transform.position, transform.rotation, transform);
               
                
                fireRateTimer = fireRate;
            }
        }
    }
}
