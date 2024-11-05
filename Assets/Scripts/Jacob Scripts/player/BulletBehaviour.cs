using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletBehaviour : MonoBehaviour
{
    private Damage _target;
    
    public void GoToDamageScript(Damage newTarget)
    {
        _target = newTarget;
    }
    
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _target.CalculateTotalDamageWithoutItems(other.gameObject);
            Destroy(gameObject);
        }
        
    }
}
