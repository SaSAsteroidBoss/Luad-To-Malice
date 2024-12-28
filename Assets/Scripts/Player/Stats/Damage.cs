using UnityEngine;

public abstract class Damage
{ 
    public abstract void CalculateDamage(GameObject dmgTarget);
    
    public abstract void CalculateAeoDamage(GameObject dmgTarget);
    
}

public class BossDamage : Damage 
{
    private readonly float _baseDamage;
    private readonly float _aeoDamage;
    private float _totalDamage;

    public BossDamage(float baseDamage, float aoeDamage)
    {
        _baseDamage = baseDamage;
        _aeoDamage = aoeDamage;
    }

    public override void CalculateDamage(GameObject dmgTarget)
    {
        //_totalDamage = _baseDamage - dmgTarget.GetComponent<Armour>().armour;
        //dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
    }

    public override void CalculateAeoDamage(GameObject dmgTarget)
    {
       // _totalDamage =_aeoDamage - dmgTarget.GetComponent<Armour>().armour;
        //dmgTarget.GetComponent<Health>().TakeDamage(_totalDamage);
    }
}


