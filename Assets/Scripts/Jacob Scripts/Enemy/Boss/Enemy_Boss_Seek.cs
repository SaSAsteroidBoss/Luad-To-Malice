using UnityEngine;

public class Enemy_Boss_Seek : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float stopThreshold;

    [SerializeField] private float basicCooldown;
    private float basicCooldownTimer = 0;

    [SerializeField] private float lungeThresholdMax;
    [SerializeField] private float lungeThresholdMin;
    private float lungeCooldownTimer;
    [SerializeField] private float lungeCooldown;

    [SerializeField] private float attackThreshold;

    public void GoToTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        lungeCooldownTimer += Time.deltaTime;
        basicCooldownTimer += Time.deltaTime;
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.transform.position) >= stopThreshold)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 1f * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, target.transform.position) <= lungeThresholdMax && Vector2.Distance(transform.position, target.transform.position) >= lungeThresholdMin && lungeCooldownTimer >= lungeCooldown)
            {
                lungeCooldownTimer = 0;
                int index = Random.Range(0, 1);
                if (index == 0) { GetComponent<Enemy_Boss_Attack>().Lunge(target); }
            }
            if (Vector2.Distance(transform.position, target.transform.position) <= attackThreshold && basicCooldownTimer >= basicCooldown)
            {
                basicCooldownTimer = 0;
                GetComponent<Enemy_Boss_Attack>().Basic(target);
            }
        }
    }
}
