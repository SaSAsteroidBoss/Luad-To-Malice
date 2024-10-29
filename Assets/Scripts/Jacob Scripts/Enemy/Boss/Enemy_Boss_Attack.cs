using UnityEngine;

public class Enemy_Boss_Attack : MonoBehaviour
{

    [Header("Basic Attack")]
    [SerializeField] private float basicDamage;
    [SerializeField] private GameObject basicHitCollider;

    [Header("Lunge Attack")]
    [SerializeField] private float lungeDamage;
    [SerializeField] private GameObject lungeHitCollider;

    [Header("AOE Attack")]
    [SerializeField] private float areaDamage;
    [SerializeField] private GameObject areaHitCollider;

    public void Basic(GameObject target)
    {
        print("Boss Basic");
        // Animate
        // Wait till animation is finished
        // Damage player
        // Start cooldown
    }

    public void Lunge(GameObject target)
    {
        print("Boss Lunge");
        // Animate
        // Wait till animation is finished
        // Damage player
        // Start Cooldown
    }

    public void Area()
    {
        print("Boss Area");
        // Animate
        // Wait till animation is finished
        // Check collider for targets
        // Damage all targets
        // Start Cooldown
    }
}
