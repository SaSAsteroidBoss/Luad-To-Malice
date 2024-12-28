using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class Stats : MonoBehaviour
{
    private ItemInventory _inventory;

    private PlayerHealth pHealth;

    private EnemyHealth eHealth;

    [SerializeField] private float _hp;

    [SerializeField] private float _maxHp;

    [SerializeField] private float _hpRegen;

    [SerializeField] private float _armour;

    [SerializeField] private float _damage;

    public float hp
    {
        get => _hp;
        set => hp = value;
    }

    public float maxHp
    {
        get => _maxHp;
        set => maxHp = value;
    }

    public float hpRegen
    {
        get => _hpRegen;
        set => hpRegen = value;
    }

    public float armour
    {
        get => _armour;
        set => armour = value;
    }

    public float damage
    {
        get => _damage;
        set => damage = value;
    }

    public ItemInventory Inventory
    {
        get => _inventory;
        set => _inventory = value;
    }

    public UnityAction<float, float> OnIncreaseStats;
  
    public UnityAction<float> OnIncreaseHealth;

    public UnityAction<float> OnIncreaseHeal;
    
    public UnityAction<float> OnIncreaseArmour;
    
    public UnityAction<float> OnHealing;

    public UnityAction<float> OnDecreaseHp;

    public UnityAction OnHealth;

    private void Awake()
    {
        if (gameObject.CompareTag("Player"))
        {
            _inventory = GetComponent<ItemInventory>();
            pHealth = GetComponent<PlayerHealth>();
        }

        if (gameObject.CompareTag("Enemy"))
        {
            eHealth = GetComponent<EnemyHealth>();
        }
    }

    public void Start()
    {
        OnHealth += HandleHealth;
        OnDecreaseHp += HandleDecreaseHp;
        OnIncreaseStats += HandleIncreaseStats;
        OnIncreaseArmour += HandleIncreaseArmour;
        OnIncreaseHealth += HandleIncreaseHealth;
        OnHealing += HandleHealing;
        OnIncreaseHeal += HandleIncreaseHeal;
    }

    private void HandleHealth()
    {
        _hp = _maxHp;
    }

    private void HandleDecreaseHp(float newHp)
    {
        _hp -= newHp;
        _hp = Mathf.Clamp(_hp, 0f, _maxHp);

        if (pHealth != null)
        {
            pHealth.OnHealth?.Invoke();
            pHealth.OnDamage?.Invoke();
        }

        if (eHealth != null)
        {
            eHealth.OnCheckHealth?.Invoke();
            eHealth.OnDamage?.Invoke();
        }
    }
    
    private void HandleIncreaseStats(float newArmour, float newHp )
    {
        _armour += newArmour;
        _maxHp += newHp;
        _hp += newHp;
    }

    private void HandleIncreaseArmour(float newArmour)
    {
        _armour += newArmour;
    }

    private void HandleIncreaseHealth(float newHp)
    {
        _maxHp += newHp;
    }
    private void HandleIncreaseHeal(float newHpRegen)
    {
        _hpRegen += newHpRegen;
    }
    
    private void HandleHealing(float newHp)
    {
        _hp += newHp;
    }

}
