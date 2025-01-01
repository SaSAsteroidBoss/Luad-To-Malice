using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float fireRate;
    private float fireRateTimer = 0;

    private List<GameObject> toHit = new List<GameObject>();

    private MeleeHitbox mhb;
    
    private Stats _stats;

    private void Start()
    {
        _stats = GetComponent<Stats>();
        mhb = GetComponentInChildren<MeleeHitbox>();
    }
    
    private void Update()
    {
        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
    }

    public void Swing()
    {
        if (fireRateTimer <= 0)
        {
            print("Player Swinging");
            toHit = mhb.enemies;
            foreach (GameObject obj in toHit)
            {
                Stats enStats = obj.GetComponent<Stats>();
                EnemyDamage enDamage = obj.GetComponent<EnemyDamage>();
                
                print("Hitting Enemy");
                if (enStats.hp <= 100)
                {
                    enDamage.Damage(_stats.damage);
                }
                
            }
        }
    }
    
}
