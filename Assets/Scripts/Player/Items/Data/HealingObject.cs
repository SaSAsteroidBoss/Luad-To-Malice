using UnityEngine;

[CreateAssetMenu(menuName = "Item/Healing Item")]

public class HealingObject : ItemObject
{
    public float mainHealValue;
   
    public float statusEffectDamage;
    
    public void Awake()
    {
        type = ItemType.Health;
    }

    public override void AddItemSource(GameObject player)
    {
        player.GetComponent<Health>().AddHealSource(this);
    }
}
