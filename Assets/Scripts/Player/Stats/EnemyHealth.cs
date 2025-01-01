using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour, IHealth
{
    private Stats _stats;

    private Enemy_Ranged_Detect detection;
    
    private float Hp
    {
        get => _stats.hp;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            Hp = value;
        }
    }

    private float MaxHp
    {
        get => _stats.maxHp;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            MaxHp = value;
        }
    }
    
    private double lastHitInterval;

    private float HitInterval = 0.5F;

    public UnityAction OnHealth;
    public UnityAction OnDamage;
    public UnityAction OnCheckHealth;
    
    private UnityAction _onDie;

    private bool dropitem;
    private bool once;
    
    public void Start()
    {
        _stats = GetComponent<Stats>();
        OnHealth += HandleHealth;
        _onDie += HandleDeath;
        OnCheckHealth += HandleCheckHealth;
        OnDamage += HandleDamage;
        
        if(gameObject.name == "Range Enemies")
        {
            detection = GetComponentInChildren<Enemy_Ranged_Detect>();
        }
    }

    private void Update()
    {
        if (Hp < MaxHp)
        {
            var timeNow = Time.time;
            
            if (timeNow > lastHitInterval + HitInterval)
            {
                _stats.OnHealing?.Invoke(_stats.hpRegen);
                
                lastHitInterval = timeNow;
            }
        }
    }
    
    private void HandleHealth()
    {
        _stats.OnIncreaseHealth.Invoke(5);
    }

    private void HandleCheckHealth()
    {
        if (Hp <= 0)
        {
            once = true;
            dropitem = true;
            _onDie?.Invoke();
        }
    }
    
    public void HandleDamage()
    {
        lastHitInterval = Time.time;
    }
    
    public void HandleDeath()
    {
        if (gameObject.name == "Range Enemies")
        {   
            detection.ResetDetection(gameObject);
            gameObject.SetActive(false);

            if (dropitem == true)
            {
                HandleDropItem();
                dropitem = false;
                
            }
            
           
            EnemyObjectPool.Instance.AddRangeEnemiesPooledObject(gameObject);
            
        }
        
        if (gameObject.name == "Melee Enemies")
        {   
            gameObject.SetActive(false);
         
            if (dropitem == true)
            {
                HandleDropItem();
                dropitem = false;
            }
            
            EnemyObjectPool.Instance.AddMeleeEnemiesPooledObject(gameObject);
            
        }
    }

    private void HandleDropItem()
    {
        var randomItemChance = Random.Range(1, 100);

        if (randomItemChance >= 20)
        {
            var itemChance = Random.Range(1, 4);

            GameObject itemDrop;

            switch (itemChance)
            {
                case 1:

                    if (once)
                    {
                        itemDrop = ItemObjectPool.Instance.GetBanagePooledObject();
                        itemDrop.transform.position = transform.position;
                        itemDrop.SetActive(true);
                        ItemObjectPool.Instance.RemoveBanagePooledObject(itemDrop);
                    
                        itemChance = -1;
                        randomItemChance = -1;
                    
                        once = false;
                    }

        
                    break;

                case 2:

                    if (once == true)
                    {
                        itemDrop = ItemObjectPool.Instance.GetBanagePooledObject();
                        itemDrop.transform.position = transform.position;
                        itemDrop.SetActive(true);
                        ItemObjectPool.Instance.RemoveBanagePooledObject(itemDrop);
                    
                        itemChance = -1;
                        randomItemChance = -1;
                    
                        once = false;
                    }
                    
                    break;

                case 3:

                    if (once == true)
                    {
                        itemDrop = ItemObjectPool.Instance.GetGelLayerPooledObject();
                        itemDrop.transform.position = transform.position;
                        itemDrop.SetActive(true);
                        ItemObjectPool.Instance.RemoveGelLayerPooledObject(itemDrop);
                    
                        itemChance = -1;
                        randomItemChance = -1;
                    
                        once = false;
                    }
                    
                    
                    
                    break;

                case 4:

                    if (once == true)
                    {
                        itemDrop = ItemObjectPool.Instance.GetSoldierBioticsPooledObject();
                        itemDrop.transform.position = transform.position;
                        itemDrop.SetActive(true);
                        ItemObjectPool.Instance.RemoveSoldierBioticsPooledObject(itemDrop);

                        itemChance = -1;
                        randomItemChance = -1;
                    
                        once = false;
                    }
                    
                    break;

            }
        }
    }
    
    
}
