using UnityEngine;

[CreateAssetMenu(menuName = "Item/Armour Item")]

public class ArmourObject : ItemObject
{
    public float mainArmour;
    
    public void Awake()
    {
        type = ItemType.Armour;
    }

    public override void AddItemSource(GameObject player)
    { 
        player.GetComponent<Armour>().AddArmourSource(this);
    }
}
    