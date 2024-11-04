using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Damage))]
public class DamageEditor:  Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        Damage damageScript = (Damage)target;
        if(GUILayout.Button("Calculate Total Damage Without Items"))
        {
           damageScript.CalculateTotalDamageWithoutItems(GameObject.Find("Player"));
        }
        
        if(GUILayout.Button("Calculate Total Damage With Items"))
        {
            damageScript.CalculateTotalDamageWithItems(GameObject.Find("Boss"));
        }
    }
}
