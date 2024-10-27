using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Object")]

public class Item : ScriptableObject
{
    public ItemType type;
    public ProcItemType procItemType;

    public float itemEffectAmount;
}
