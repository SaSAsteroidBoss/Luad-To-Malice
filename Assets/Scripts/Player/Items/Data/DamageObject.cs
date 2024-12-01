using UnityEngine;

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
        player.GetComponent<ItemInventory>().PlayerDamage.AddDamageSource(this);
    }
}
