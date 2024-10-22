using UnityEngine;
using System.Collections;

/// <summary>
/// script should be attatched to the player Object.
/// Create an empty child object in the centre of the player and add your gun object to that. 
/// It must be named "Gun"
/// Example:
/// |-- Player/
/// |   |-- Pivot/
/// |   |   |-- Gun/
/// </summary>

public class aimControllerTwo : MonoBehaviour
{
    private AimData AimData;
    private bool canRun = false;

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
                canRun = true;
                playerClass.gunOffSet = AimData.radius;
            }
        }
        if (canRun == false)
        {
            Debug.LogWarning("Could not find child object named Gun for AimControllerTwo.cs please Check Script Descripton for correct setup ");
        }
    }
    private void Update()
    {
        if (canRun)
        {
            Vector3 orbitVector = Camera.main.WorldToScreenPoint(AimData.pivot.position);

            orbitVector = Input.mousePosition - orbitVector;

            float angle = Mathf.Atan2(-orbitVector.y, -orbitVector.x) * Mathf.Rad2Deg;
            
            AimData.pivot.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            playerClass.gunAngle = angle;
            Vector3 pos = AimData.pivot.position;
            

        }
    }

}
