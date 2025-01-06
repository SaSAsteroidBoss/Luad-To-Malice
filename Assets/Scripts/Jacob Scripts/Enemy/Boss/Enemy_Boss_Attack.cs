using System;
using System.Collections;
using UnityEngine;

public class Enemy_Boss_Attack : MonoBehaviour
{

    [Header("Basic Attack")]
    [SerializeField] private float basicDamage;

    [Header("AOE Attack")]
    [SerializeField] private float areaDamage;

    private Stats _stats;

    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    public void Basic(GameObject target)
    {
        print("Boss Basic");
        // Animate
        // Wait till animation is finished
        // Damage player
        
       target.GetComponent<PlayerDamage>().Damage(_stats.damage);
    }

    public void Lunge(GameObject target)
    {
        print("Boss Lunge activated, speed doubled");
        // Animate
        GetComponent<Enemy_Boss_Seek>().speed = GetComponent<Enemy_Boss_Seek>().speed * 10;
        
        target.GetComponent<PlayerDamage>().Damage(_stats.damage);
    }

    public void AOE()
    {
        print("Boss AOE activated");
        //Animate
        //Damage Players
        foreach (GameObject g in GetComponentInChildren<Enemy_Boss_AOE_Detect>().playersVulnurable) 
        {
            g.GetComponent<PlayerDamage>().Damage(_stats.damage);
        }
    }
}
