using System;
using UnityEngine;

public class IPlayerDamage : MonoBehaviour, IDamage
{
    private Stats _stats;
    
    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    public void Damage(int damage)
    {
      
    }
}
