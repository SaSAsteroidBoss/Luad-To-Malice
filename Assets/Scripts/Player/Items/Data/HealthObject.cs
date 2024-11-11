using UnityEngine;

public class HealthObject : ItemObject
{
    public float mainHealthIncrease;
   
    public float statusEffectDamage;
    
    public void Awake()
    {
        type = ItemType.Damage;
    }

    public override void AddItemSource(GameObject player)
    {
        player.GetComponent<Health>().AddHealthSource(this);
    }
}
