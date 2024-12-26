using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletBehaviour : MonoBehaviour
{
    
    public float speed;

    public float damage;

    private void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            other.gameObject.GetComponent<IPlayerDamage>().Damage(damage);
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
    }
}
