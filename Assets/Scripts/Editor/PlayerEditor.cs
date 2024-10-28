using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Health))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Health myScript = (Health)target;
        if(GUILayout.Button("TakeDamage"))
        {
            myScript.TakeDamage(25);
        }
    }
}
