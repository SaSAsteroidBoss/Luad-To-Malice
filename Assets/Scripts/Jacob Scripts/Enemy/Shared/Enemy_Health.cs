using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Hitbox Entry Detected");
        if (collision.CompareTag("Bullet"))
        {
            print("Bullet Hit Detected");
            DealDamage(collision.GetComponent<BulletBehaviour>().damage);
        }
    }

    public void DealDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        print("Hit Dealing " + dmg + " Damage, " + health + " Health Remaining.");
    }
}
