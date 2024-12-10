using System;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    private TempHealth _health;
    
    private int _hp;
    private int _maxHp;
    private int _hpRegen;

    private int _armour;

    public int Hp { get => _hp; set => Hp = value; }

    public int MaxHp { get => _maxHp;  set => MaxHp = value;   }

    public int HpRegen {  get => _hpRegen; set => HpRegen = value;  }

    public int Armour {  get => _armour; set =>Armour = value;  }

    private void Start()
    {
         _health = GetComponent<TempHealth>();
         _health.UpdateHp += UpdateHp;
    }

    private void UpdateHp(int newHp)
    {
        _hp = newHp;
        _hp = (int)Mathf.Clamp(_hp, 0f,  _maxHp);
    }

    

}
