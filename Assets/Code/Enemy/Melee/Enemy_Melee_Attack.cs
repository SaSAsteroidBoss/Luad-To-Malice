using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee_Attack : MonoBehaviour
{

    public List<GameObject> toHit = new List<GameObject>();

    public float fireRate;
    private float fireRateTimer = 0;

    private void Update()
    {
        fireRateTimer -= Time.deltaTime;
        if (fireRateTimer <= 0 && GetComponentInChildren<EnemyMeleeHitbox>().players.Count > 0)
        {
            EnemySwing();
        }
    }

    private void EnemySwing()
    {
        print("Enemy Swinging");
        toHit = GetComponentInChildren<EnemyMeleeHitbox>().players;
        foreach (GameObject obj in toHit)
        {
            print("Hitting player");
            if (obj.GetComponentInChildren<Enemy_Health>().health <= 25) { GetComponentInChildren<EnemyMeleeHitbox>().players.Remove(obj); }
            obj.GetComponentInChildren<Enemy_Health>().DealDamage(25);
        }
        fireRateTimer = fireRate;
    }
}
