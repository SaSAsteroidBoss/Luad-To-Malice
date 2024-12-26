using System;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    private ItemInventory _inventory;
    
    [SerializeField]
    private float  _hp;
    
    [SerializeField]
    private float _maxHp;
  
    [SerializeField]
    private float  _hpRegen;
   
    [SerializeField]
    private float  _armour;

    [SerializeField]
    private float _damage;

    public float hp { get => _hp; set  => hp = value; }

    public float maxHp { get => _maxHp;  set => maxHp = value;   }

    public float hpRegen {  get => _hpRegen; set => hpRegen = value;  }

    public float armour {  get => _armour; set =>armour = value;  }
    
    public float damage{  get => _damage; set =>damage = value;  }
    
    public ItemInventory inventory { get => _inventory; set => _inventory = value; }
    
    public UnityAction<float> UpdateHp;
    
    private void Awake()
    {
        if (gameObject.CompareTag("Player"))
        {
            _inventory = GetComponent<ItemInventory>();
        }
    }

    private void Start()
    {
         UpdateHp += TakeHpDamage;
    }

    private void TakeHpDamage(float newHp)
    {
        _hp -= newHp;
        _hp = Mathf.Clamp(_hp, 0f,  _maxHp);
    }

}
