using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class WaveCollision : MonoBehaviour
{
  
    [SerializeField]
    private ItemInventory inventory;
    
    
    private PlayerDamage PlayerDamage
    {
        get => inventory.PlayerDamage;
        set
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            PlayerDamage = value ?? throw new ArgumentNullException(nameof(value));
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            PlayerDamage.CalculateDamage(other.gameObject);
        }

    }
}
