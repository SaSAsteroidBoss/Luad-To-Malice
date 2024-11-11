using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemInventory))]
public class ItemInventoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        ItemInventory itemInventoryScript = (ItemInventory)target;
        if(GUILayout.Button("GetAndAddItem"))
        {
            itemInventoryScript.GetAndAddItem();
        }
    }
}
