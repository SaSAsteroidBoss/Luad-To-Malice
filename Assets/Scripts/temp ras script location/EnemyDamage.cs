using UnityEngine;

public class EnemyDamage : MonoBehaviour, IDamage
{
    private Stats _stats;

    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    public void Damage(int damage)
    {
        
    }
}
