using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee_Attack : MonoBehaviour
{

    public List<GameObject> toHit {get{return hitbox.players;} set{ toHit = value;}}

    EnemyMeleeHitbox hitbox;
    [SerializeField]
    private float damage;
    public float fireRate;
    private float fireRateTimer = 0;

    private void Start()
    {
        //toHit = GetComponentInChildren<EnemyMeleeHitbox>().players;
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
                print("hitting " + obj.name);
                
                obj.gameObject.GetComponent<PlayerDamage>().Damage(damage);
                break;
            }
           
        }

    fireRateTimer = fireRate;
    /*
        toHit = GetComponentInChildren<EnemyMeleeHitbox>().players;
        foreach (GameObject obj in toHit)
        {
            print("Hitting player");
            if (obj.GetComponentInChildren<Enemy_Health>().health <= 25) { GetComponentInChildren<EnemyMeleeHitbox>().players.Remove(obj); }
            obj.GetComponentInChildren<Enemy_Health>().DealDamage(25);
        }
        fireRateTimer = fireRate;
    */
    }

}
