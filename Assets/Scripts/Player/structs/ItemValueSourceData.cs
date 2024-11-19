using System;
using UnityEngine;

[Serializable]
public struct ItemValueSourceData
{
    public ItemObject item;
    
    public string sourceName;

    public float primaryValue;
    
    public float secondaryValue;
    
    public float thirdValue;
    
    public int amount;
}
