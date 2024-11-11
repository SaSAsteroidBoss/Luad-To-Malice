using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float fireRate;
    private float fireRateTimer = 0;

    private List<GameObject> toHit = new List<GameObject>();

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
            toHit = GetComponentInChildren<MeleeHitbox>().enemies;
            foreach (GameObject obj in toHit)
            {
                print("Hitting Enemy");
                if (obj.GetComponentInChildren<Enemy_Health>().health <= 100) { GetComponentInChildren<MeleeHitbox>().enemies.Remove(obj); }
                obj.GetComponentInChildren<Enemy_Health>().DealDamage(100);
            }
        }
    }
    
}
