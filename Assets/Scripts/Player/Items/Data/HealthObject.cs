using UnityEngine;

[CreateAssetMenu(menuName = "Item/Health Item")]

public class HealthObject : ItemObject
{
    public float mainHealthIncrease;
   
    public float statusEffectDamage;
    
    public void Awake()
    {
        type = ItemType.Health;
    }

    public override void AddItemSource(GameObject player)
    {
        player.GetComponent<Health>().AddHealthSource(this);
    }
}
