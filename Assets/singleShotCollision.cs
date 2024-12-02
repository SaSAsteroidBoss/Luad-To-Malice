using System;
using UnityEngine;

public class singleShotCollision : MonoBehaviour
{
  private PlayerDamage _target;


  public void SetDamageScript(PlayerDamage newTarget)
  {
    _target = newTarget;
  }


  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.CompareTag("Enemy"))
    {
      _target.CalculateDamage(other.gameObject);
      Destroy(gameObject);
    }
  }
}
