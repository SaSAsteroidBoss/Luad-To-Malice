using System;
using UnityEngine;
using UnityEngine.Profiling;


public class AimController : MonoBehaviour
{
    public float raduis = 0.1f;
    public Transform orb; 
    public Transform pivot;

    private void Start()
    {
        pivot = orb.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * raduis;
    }

    private void Update()
    {
        Profiler.BeginSample("Aim Controller One");
        Vector3 orbitVector = Camera.main.WorldToScreenPoint(orb.position);
        orbitVector = Input.mousePosition - orbitVector;

        float angle = Mathf.Atan2(orbitVector.y, orbitVector.x) * Mathf.Rad2Deg;

        //pivot.position = orb.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        Profiler.EndSample();
    }
}
