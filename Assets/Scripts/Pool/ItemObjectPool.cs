using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItemObjectPool : MonoBehaviour
{
    public static ItemObjectPool Instance;
    
    private List<GameObject> _electricBoogaloo = new List<GameObject>();  
    
    private List<GameObject> _banage = new List<GameObject>(); 
    
    private List<GameObject> _soldierBiotics = new List<GameObject>();
    
    private List<GameObject> _gelLayer = new List<GameObject>();
    
    [SerializeField] private int amountToPoolElectricBoogaloo = 20;
    
    [SerializeField]  private GameObject electricBoogalooPrefab;
    
    [SerializeField]  private GameObject soldierBioticsPrefab; 
    
    [SerializeField] private int amountToPoolSoldierBiotics = 20; 
    
    [SerializeField]  private GameObject banagePrefab; 
    
    [SerializeField] private int amountToPoolBanage = 20;  
    
    [SerializeField]  private GameObject gelLayerPrefab; 
    
    [SerializeField] private int amountToPoolGelLayer = 20;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }


        for (int i = 0; i < amountToPoolElectricBoogaloo; i++)
        {
            var localElectricBoogaloo = Instantiate(electricBoogalooPrefab);
            localElectricBoogaloo.name = "Electric Boogaloo" + " " + i;
            localElectricBoogaloo.gameObject.SetActive(false);
            _electricBoogaloo.Add(localElectricBoogaloo);
        }
        
        for (int i = 0; i < amountToPoolSoldierBiotics; i++)
        {
            var localSoldierBiotics = Instantiate(soldierBioticsPrefab);
            localSoldierBiotics.name = "Soldier Biotics" + " " + i;
            localSoldierBiotics.gameObject.SetActive(false);
            _soldierBiotics.Add(localSoldierBiotics);
        }  
        
        for (int i = 0; i < amountToPoolBanage; i++)
        {
            var localBanage = Instantiate(banagePrefab);
            localBanage.name = "Banage" + " " + i;
            localBanage.gameObject.SetActive(false);
            _banage.Add(localBanage);
        }   
        
        for (int i = 0; i < amountToPoolGelLayer; i++)
        {
            var localGelLayer = Instantiate(gelLayerPrefab);
            localGelLayer.name = "Gel Layer" + " " + i;
            localGelLayer.gameObject.SetActive(false);
            _gelLayer.Add(localGelLayer);
        }
    }

    public GameObject GetElectricBoogalooPooledObject()
    {
        for (int i = 0; i < _electricBoogaloo.Count; i++)
        {
            if (!_electricBoogaloo[i].activeInHierarchy)
            {
                return _electricBoogaloo[i];
            }

        }

        return null;
    }

    public void RemoveElectricBoogalooPooledObject(GameObject localElectricBoogaloo)
    {
        if (localElectricBoogaloo != null)
        {
            _electricBoogaloo.Remove(localElectricBoogaloo);
        }
    }

    public void AddElectricBoogalooPooledObject(GameObject localElectricBoogaloo)
    {
        if (localElectricBoogaloo != null)
        {
            localElectricBoogaloo.SetActive(false);
            _electricBoogaloo.Add(localElectricBoogaloo);
        }
    }  
    
    
    public GameObject GetSoldierBioticsPooledObject()
    {
        for (int i = 0; i < _soldierBiotics.Count; i++)
        {
            if (!_soldierBiotics[i].activeInHierarchy)
            {
                return _soldierBiotics[i];
            }

        }

        return null;
    }

    public void RemoveSoldierBioticsPooledObject(GameObject localSoldierBiotics)
    {
        if (localSoldierBiotics != null)
        {
            _soldierBiotics.Remove(localSoldierBiotics);
        }
    }

    public void AddSoldierBioticsPooledObject(GameObject localSoldierBiotics)
    {
        if (localSoldierBiotics != null)
        {
            localSoldierBiotics.SetActive(false);
            _soldierBiotics.Add(localSoldierBiotics);
        }
    }
    
    public GameObject GetBanagePooledObject()
    {
        for (int i = 0; i < _banage.Count; i++)
        {
            if (!_banage[i].activeInHierarchy)
            {
                return _banage[i];
            }

        }

        return null;
    }

    public void RemoveBanagePooledObject(GameObject localBanage)
    {
        if (localBanage != null)
        {
            _banage.Remove(localBanage);
        }
    }

    public void AddBanagePooledObject(GameObject localBanage)
    {
        if (localBanage != null)
        {
            localBanage.SetActive(false);
            _banage.Add(localBanage);
        }
    } 
    
    
    public GameObject GetGelLayerPooledObject()
    {
        for (int i = 0; i < _gelLayer.Count; i++)
        {
            if (!_gelLayer[i].activeInHierarchy)
            {
                return _gelLayer[i];
            }

        }

        return null;
    }

    public void RemoveGelLayerPooledObject(GameObject localGelLayer)
    {
        if (localGelLayer != null)
        {
            _gelLayer.Remove(localGelLayer);
        }
    }

    public void AddGelLayerPooledObject(GameObject localGelLayer)
    {
        if (localGelLayer != null)
        {
            localGelLayer.SetActive(false);
            _gelLayer.Add(localGelLayer);
        }
    }
}
