using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Melee_Seek : MonoBehaviour
{

    public GameObject target;

    public void GoToTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, .01f);
        }
    }
}
