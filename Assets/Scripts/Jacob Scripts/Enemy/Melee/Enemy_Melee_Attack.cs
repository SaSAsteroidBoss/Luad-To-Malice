using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee_Attack : MonoBehaviour
{

    public List<GameObject> toHit {get{return hitbox.players;} set{ toHit = value;}}

    EnemyMeleeHitbox hitbox;
    public float fireRate;
    private float fireRateTimer = 0;
    
    private Stats _stats;

    private void Start()
    {
        hitbox = GetComponentInChildren<EnemyMeleeHitbox>();
    }
    private void Update()
    {
        fireRateTimer -= Time.deltaTime;
        if (fireRateTimer <= 0 && hitbox.players.Count > 0)
        {
            EnemySwing();
        }
    }

    private void EnemySwing()
    {
        
        print("Enemy Swinging");
        
        foreach (GameObject obj in toHit)
        {
            if(obj != null)
            {
                obj.gameObject.GetComponent<PlayerDamage>().Damage(_stats.damage);
                break;
            }
           
        }

    fireRateTimer = fireRate;
    }
}
