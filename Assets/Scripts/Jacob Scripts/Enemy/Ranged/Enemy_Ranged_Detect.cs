using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged_Detect : MonoBehaviour
{

    public GameObject preTarget;

    public GameObject target;

    private Enemy_Ranged_Seek ers;

    private void Start()
    {
        ers = GetComponentInParent<Enemy_Ranged_Seek>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If a player has entered range
        if (collision.CompareTag("Player"))
        {
            print("Player detected by enemy");
            // If there is no pre-target
            if (preTarget != null)
            {
                if (Vector2.Distance(transform.position, collision.transform.position) <
                    Vector2.Distance(transform.position, preTarget.transform.position))
                {
                    preTarget = collision.gameObject;
                }
            }
            else
            {
                preTarget = collision.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If there is a target
        if (target != null)
        {
            // If there is a second target in range
            if (preTarget != null)
            {
                // Check if the new target is closer than the current target
                if (Vector2.Distance(transform.position, preTarget.transform.position) >
                    Vector2.Distance(transform.position, target.transform.position))
                {
                    // Set them as the current target
                    ers.GoToTarget(preTarget);
                    target = preTarget;
                    preTarget = null;
                    print("New target set");
                }
            }
        }
        else
        {
            // If there is no target but a preTarget
            if (preTarget != null)
            {
                // Set them as the current target
                ers.GoToTarget(preTarget);
                target = preTarget;
                preTarget = null;
                print("New target set");
            }
        }
    }


    public void ResetDetection(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            if (obj == target.gameObject)
            {
                ers.target = null;
                target = null;
            }

            if (obj == preTarget.gameObject)
            {
                preTarget = null;
            }
            
        }

    }
}


