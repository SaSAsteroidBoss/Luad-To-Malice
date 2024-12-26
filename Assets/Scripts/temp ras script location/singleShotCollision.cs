using System;
using UnityEngine;

public class singleShotCollision : MonoBehaviour
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
    if (other.gameObject.CompareTag("Enemy"))
    {
      var dmgScript = other.GetComponent<EnemyDamage>();
      dmgScript.UpdateInventory?.Invoke(_itemInventory);
      dmgScript.Damage(_stats.damage);
    }
  }
}
