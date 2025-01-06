using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee_Attack : MonoBehaviour
{
    public GameObject hitboxPrefab;
    public List<GameObject> toHit {get{return hitbox.players;} set{ toHit = value;}}

    EnemyMeleeHitbox hitbox;
    public float fireRate;
    private float fireRateTimer = 0;
    
    private Stats _stats;

    private void Start()
    {
        _stats = GetComponent<Stats>();
        hitbox = GetComponentInChildren<EnemyMeleeHitbox>();
    }
    private void Update()
    {
        fireRateTimer -= Time.deltaTime;
       // if (fireRateTimer <= 0 && hitbox.players.Count > 0)
       if(fireRateTimer <= 0)
        {
            EnemySwing();
        }
    }

    private void EnemySwing()
    {
        var instance = Instantiate(hitboxPrefab, transform.position, transform.rotation);
        var hitbox = instance.GetComponent<meleeHitBoxPrefab>();
        hitbox.Setup(_stats);
        if(hitbox != null)
        {
            hitbox.Setup(_stats);
        }

        //print("Enemy Swinging");
        
        /*
        foreach (GameObject obj in toHit)
        {
            if(obj != null)
            {
                obj.gameObject.GetComponent<PlayerDamage>().Damage(_stats.damage);
                break;
            }
           
        }
         */
    fireRateTimer = fireRate;
    }
}
