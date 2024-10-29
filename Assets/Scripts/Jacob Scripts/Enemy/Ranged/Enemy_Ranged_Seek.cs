using UnityEngine;

public class Enemy_Ranged_Seek : MonoBehaviour
{
    public GameObject target;

    public float stopThreshold;
    public float backupThreshold;

    public void GoToTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.transform.position) <= backupThreshold)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, -.01f);
            }
            else if (Vector2.Distance(transform.position, target.transform.position) >= stopThreshold)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, .01f);
            }
        }
    }
}
