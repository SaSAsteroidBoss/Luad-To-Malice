using UnityEngine;

//ignore this I was just having a bit of fun with structs 
// this is not to be used because transforms are refrence type so not suitable with structs

public class aimControllerTwo : MonoBehaviour
{
    private AimData AimData;

    private void Start()
    {
        AimData.radius = 0.5f;
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == "Gun")
            {
                AimData.orb = child;
                AimData.pivot = child.parent;
                AimData.orb.position += Vector3.up * AimData.radius;
            }
        }
    }
    private void Update()
    {
        Vector3 orbitVector = Camera.main.WorldToScreenPoint(AimData.orb.position);
        orbitVector = Input.mousePosition - orbitVector;
  
        float angle = Mathf.Atan2(-orbitVector.y, -orbitVector.x) * Mathf.Rad2Deg;
    
        AimData.pivot.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);  
    }

}
