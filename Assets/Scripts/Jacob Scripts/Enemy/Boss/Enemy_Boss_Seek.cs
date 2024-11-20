using UnityEngine;

public class Enemy_Boss_Seek : MonoBehaviour
{
    public float speed;

    public GameObject target;
    [SerializeField] private float stopThreshold;
    [SerializeField] private float attackThreshold;

    [SerializeField] private float basicCooldown;
    private float basicCooldownTimer = 0;

    [Header("Lunge Attack")]
    [SerializeField] private float lungeThresholdMax;
    [SerializeField] private float lungeThresholdMin;
    private float lungeCooldownTimer = 10;
    [SerializeField] private float lungeCooldown;
    private bool lungeBoostActive;
    private float lungeBoostTimer;

    [Header("AOE Attack")]
    private float AOECooldownTimer;
    [SerializeField] private float AOECooldown;

    public void GoToTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        lungeCooldownTimer += Time.deltaTime;
        basicCooldownTimer += Time.deltaTime;
        AOECooldownTimer += Time.deltaTime;
        lungeBoostTimer -= Time.deltaTime;
        if (lungeBoostTimer <= 0 && lungeBoostActive)
        {
            print("Lunge over, returning speed to normal");
            speed /= 10;
            lungeBoostActive = false;
        }
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.transform.position) >= stopThreshold)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, target.transform.position) <= lungeThresholdMax && Vector2.Distance(transform.position, target.transform.position) >= lungeThresholdMin && lungeCooldownTimer >= lungeCooldown)
            {
                print("Rolling possibility to lunge");
                lungeCooldownTimer = 0;
                int index = Random.Range(0, 1);
                // 50 percent chance to initiate a lunge attack
                if (index == 0) { GetComponent<Enemy_Boss_Attack>().Lunge(target); }
                lungeBoostTimer = .5f;
                lungeBoostActive = true;
            }
            if (Vector2.Distance(transform.position, target.transform.position) <= attackThreshold && basicCooldownTimer >= basicCooldown)
            {
                // Initiate AOE attack if more than one enemy would be hit
                if (GetComponentInChildren<Enemy_Boss_AOE_Detect>().playersVulnurable.Count > 1 && AOECooldownTimer >= AOECooldown)
                {
                    AOECooldownTimer = 0;
                    GetComponent<Enemy_Boss_Attack>().AOE();
                }
                // Otherwise do a basic
                else
                {
                    basicCooldownTimer = 0;
                    GetComponent<Enemy_Boss_Attack>().Basic(target);
                }
            }
        }
    }
}