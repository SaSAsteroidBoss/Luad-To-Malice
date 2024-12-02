using UnityEngine;

public struct AimData
{
    public float radius;
    public Transform orb;
    public Transform pivot;
   

    public AimData(float radius, Transform orb, Transform pivot)
    {
        this.radius = radius;
        this.orb = orb;
        this.pivot = pivot;
    }
}