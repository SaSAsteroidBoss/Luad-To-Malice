using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class WaveCollision : MonoBehaviour
{


    [SerializeField]
    private ItemInventory itemInventory;
    
    [SerializeField]
    private Stats stats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            var dmgScript = other.GetComponent<EnemyDamage>();
            dmgScript.UpdateInventory?.Invoke(itemInventory);
            dmgScript.Damage(stats.damage);
         
        }

    }
}
