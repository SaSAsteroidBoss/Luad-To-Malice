using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_Ranged_Attack : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public float fireRate;
  
    private float fireRateTimer = 0;

    public float attackRange;
    
    private Stats _stats;

    private Enemy_Ranged_Seek ers;
    
    private void Start()
    {
        fireRateTimer = fireRate;
        _stats = GetComponent<Stats>();
        ers = GetComponent<Enemy_Ranged_Seek>();
    }

    private void Update()
    {
        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
        if (ers.target)
        {
            if (fireRateTimer <= 0 && Vector2.Distance(transform.position, ers.target.transform.position) <= attackRange)
            {
                //print("Firing Player Projectile");
                Vector3 diff = ers.target.transform.position - transform.position;
                diff.Normalize();
                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                
               var obj =  Instantiate(bulletPrefab, transform.position, transform.rotation); 
               var bullet = obj.GetComponent<BulletBehaviour>();

               if (bullet != null)
               {
                   bullet.Setup(_stats);
               }
               
               fireRateTimer = fireRate;
            }
        }
    }
}
