using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TwinStickControls))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TwinStickControls myScript = (TwinStickControls)target;
        if(GUILayout.Button("AddItemToInventory"))
        {
            myScript.AddItemToInventory();
        }
    }
}
