using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class WaveCollision : MonoBehaviour
{
  
    [SerializeField]
    private ItemInventory inventory;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.LogError("PLAYER CAN'T DO DO DAMAGE!!!!!!");
        }

    }
}
