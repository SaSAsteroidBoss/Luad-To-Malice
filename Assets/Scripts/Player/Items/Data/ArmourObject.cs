using UnityEngine;

[CreateAssetMenu(menuName = "Item/Armour Item")]

public class ArmourObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Armour;
    }

    public override void AddItemSource(GameObject player)
    { 
        player.GetComponent<PlayerArmour>().OnArmour?.Invoke();
    }
}
    