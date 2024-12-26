using UnityEngine;

public class blastCollision : MonoBehaviour
{
    public void SetInventory(ItemInventory localInventory)
    {
        _itemInventory = localInventory;
    }
    
    public void SetStat(Stats localStats)
    {
        _stats = localStats;
    }

    private ItemInventory _itemInventory;
    private Stats _stats;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.gameObject != null)
        {
            var dmgScript = other.GetComponent<EnemyDamage>();
            dmgScript.UpdateInventory?.Invoke(_itemInventory);
            dmgScript.Damage(_stats.damage);
        }
    }
}
