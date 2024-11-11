using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Item/Damage Item")]

public class DamageObject : ItemObject
{
   public float mainDamage;
   
   public float statusEffectDamage;
    
    public void Awake()
    {
        type = ItemType.Damage;
    }

    public override void AddItemSource(GameObject player)
    {
        player.GetComponent<Damage>().AddDamageSource(this);
    }
}
