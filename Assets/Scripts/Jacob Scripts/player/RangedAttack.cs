using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireRate;
    private float fireRateTimer = 0;

    private void Update()
    {
        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if (fireRateTimer <= 0)
        {
            print("Firing Player Projectile");
            Instantiate(bulletPrefab, transform.position, transform.rotation, transform);
            fireRateTimer = fireRate;
        }
    } 
}
