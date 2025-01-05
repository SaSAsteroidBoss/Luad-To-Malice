using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private IEnumerator _heal;
    
    public float currentHealth;

    public float maxHealth;

    public float healAmount;

    [SerializeField]
    private ItemSlotData [] _healthSource;
  
    [SerializeField]
    private ItemSlotData [] _healingSource;
    
    private Enemy_Ranged_Detect detection;

    private Transform _playerSpawnPos;
    
    
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Start()
    {
       
        
        if(gameObject.CompareTag("Enemy"))
        {
            detection = GetComponentInChildren<Enemy_Ranged_Detect>();
        }
        else if (gameObject.CompareTag("Player"))
        {
            _playerSpawnPos = gameObject.transform;
        }
    }

    public void SetHealth()
    {
        currentHealth = maxHealth;
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void TakeDamage(float damage)
    {
        print(gameObject.name + " takes " + damage + " damage");
        
        var healthBefore = currentHealth;
        
        //print(currentHealth+ " current Health" + gameObject.name + " had " + healthBefore );
        
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (_heal == null && gameObject.CompareTag("Player"))
        {
            _heal = Heal();
            StartCoroutine(_heal);
        }

        if (currentHealth == 0)
        {
            if (gameObject.CompareTag("Enemy") && gameObject.name != "Boss")
            {
                var itemDrop = new GameObject();
                
                detection.ResetDetection(gameObject);
                
                gameObject.SetActive(false);
                EnemyObjectPool.Instance.AddRangeEnemiesPooledObject(gameObject);
                
                var randomItemChance = Random.Range(1, 100);

                if (randomItemChance >= 20)
                {
                    var itemChance = Random.Range(1, 4);

                    switch (itemChance)
                    {
                        case 1:

                            itemDrop = ItemObjectPool.Instance.GetBanagePooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveBanagePooledObject(itemDrop);
                            
                            break; 
                        
                        case 2:
                           
                            itemDrop = ItemObjectPool.Instance.GetElectricBoogalooPooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveElectricBoogalooPooledObject(itemDrop);
                         
                            break;
                      
                        case 3:

                            itemDrop = ItemObjectPool.Instance.GetGelLayerPooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveGelLayerPooledObject(itemDrop);
                            
                            break;
                        
                        case 4:

                            itemDrop = ItemObjectPool.Instance.GetSoldierBioticsPooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveSoldierBioticsPooledObject(itemDrop);
                            
                            break;
                        
                    }
                }

            }
            if (gameObject.CompareTag("Enemy") && gameObject.name == "Boss")
            {
                var itemDrop = new GameObject();
                
                var randomItemChance = Random.Range(1, 100);

                if (randomItemChance >= 20)
                {
                    var itemChance = Random.Range(1, 4);

                    switch (itemChance)
                    {
                        case 1:

                            itemDrop = ItemObjectPool.Instance.GetBanagePooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveBanagePooledObject(itemDrop);
                            
                            break; 
                        
                        case 2:
                           
                            itemDrop = ItemObjectPool.Instance.GetElectricBoogalooPooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveElectricBoogalooPooledObject(itemDrop);
                         
                            break;
                      
                        case 3:

                            itemDrop = ItemObjectPool.Instance.GetGelLayerPooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveGelLayerPooledObject(itemDrop);
                            
                            break;
                        
                        case 4:

                            itemDrop = ItemObjectPool.Instance.GetSoldierBioticsPooledObject();
                            itemDrop.transform.position = transform.position;
                            itemDrop.SetActive(true);
                            ItemObjectPool.Instance.RemoveSoldierBioticsPooledObject(itemDrop);
                            
                            break;
                        
                    }
                }

                Destroy(gameObject);
            }
            if (gameObject.CompareTag("Player"))
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);
               //Invoke("RevivePlayer", 2f);
            }
        }
    }

    private void RevivePlayer()
    {
        currentHealth = maxHealth;
        gameObject.transform.position = _playerSpawnPos.position;
        gameObject.SetActive(true);
        
    }

    public void AddHealAmount(float increaseHealAmount)
    {
        healAmount += increaseHealAmount;
    }
    
    public void AddHealthAmount(float increaseHealthAmount)
    {
        maxHealth += increaseHealthAmount;
    }

    private IEnumerator Heal()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (currentHealth < maxHealth)
            { 
                Debug.Log("Heal has enough health");
                var healHealth = (healAmount / maxHealth) * 100;
                currentHealth += healHealth;
            }

            if (currentHealth >= maxHealth)
            {
                Debug.Log("Heal has reached max health");
                currentHealth = maxHealth;
                StopCoroutine(_heal);
                _heal = null;
            }
          
        }
    }

    
    public void AddHealthSource(HealthObject item)
    {
        for (var i = 0; i < _healthSource.Length; i++)
        {
            if (_healthSource[i].item == item && _healthSource[i].sourceName == item.name)
            {
                _healthSource[i].amount++;
                CalculatePlayerTotalHealth();
                
                Debug.Log("Object Already Add");

                break;

            }
            else if (_healthSource[i].item == null && _healthSource[i].sourceName == string.Empty)
            {
                _healthSource[i].item = item;
                _healthSource[i].sourceName = item.itemName;
                _healthSource[i].primaryValue = item.mainHealthIncrease;
                _healthSource[i].amount = 1;

                CalculatePlayerTotalHealth();
                
                Debug.Log("Object Not Add");
                 
                break;

            }

        }
    }

    public void AddHealSource(HealingObject item)
    {
        for (var i = 0; i < _healingSource.Length; i++)
        {
            if (_healingSource[i].item == item && _healingSource[i].sourceName == item.name)
            {
                _healingSource[i].amount++;
                CalculatePlayerTotalHealing();
                
                Debug.Log("Object Already Add");

                break;

            }
            else if (_healingSource[i].item == null && _healingSource[i].sourceName == string.Empty)
            {
                _healingSource[i].item = item;
                _healingSource[i].sourceName = item.itemName;
                _healingSource[i].primaryValue = item.mainHealValue;
                _healingSource[i].amount = 1;
                CalculatePlayerTotalHealing();
                 
                Debug.Log("Object Not Add");
                 
                break;

            }

        }
    }
    
    public void CalculatePlayerTotalHealing()
    {
     
        for (var i = 0; i <_healingSource.Length; i++)
        {
            if (_healingSource[i].sourceName == "Banage")
            {   
                float healValue = _healingSource[i].primaryValue * _healingSource[i].amount;
                AddHealAmount(healValue);
            }
        }
    }
    
    void CalculatePlayerTotalHealth()
    {
        for (var i = 0; i <_healthSource.Length; i++)
        {
            if (_healthSource[i].sourceName == "Soldier Biotics")
            {   
                AddHealthAmount(_healthSource[i].primaryValue);
            }
        }
    }
}