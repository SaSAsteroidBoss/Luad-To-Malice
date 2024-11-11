using UnityEngine;

public abstract class ItemObject : ScriptableObject
{
    public ItemType type;
    
    public ProcType procType;

    public string itemName;
    
    public float duration;

    public abstract void AddItemSource(GameObject player);
}
