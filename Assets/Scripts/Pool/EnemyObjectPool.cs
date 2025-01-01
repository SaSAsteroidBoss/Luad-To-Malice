using System.Collections.Generic;
using UnityEngine;
public class EnemyObjectPool : MonoBehaviour
{
    private GameDirector _director;
    
    public static EnemyObjectPool Instance;

    private readonly List<GameObject> _rangeEnemies = new List<GameObject>();

    [SerializeField] private int amountToPoolRangeEnemies = 20;

    [SerializeField] private GameObject rangeEnemiesPrefab;
    
    private readonly List<GameObject> _meleeEnemies = new List<GameObject>();

    [SerializeField] private int amountToPoolMeleeEnemies = 20;

    [SerializeField] private GameObject meleeEnemiesPrefab;
    
    private void Awake()
    {
        _director = FindAnyObjectByType<GameDirector>();
        
        if (Instance == null)
        {
            Instance = this;
        }
        
        for (int i = 0; i < amountToPoolRangeEnemies; i++)
        {
            var localRangeEnemies = Instantiate(rangeEnemiesPrefab);
            localRangeEnemies.name = "Range Enemies";
            localRangeEnemies.gameObject.SetActive(false);
            _rangeEnemies.Add(localRangeEnemies);
            _director.OnEnemies?.Invoke(localRangeEnemies);
        }
     
        for (int i = 0; i < amountToPoolMeleeEnemies; i++)
        {
            var localMeleeEnemies = Instantiate(meleeEnemiesPrefab);
            localMeleeEnemies.name = "Melee Enemies";
            localMeleeEnemies.gameObject.SetActive(false);
            _meleeEnemies.Add(localMeleeEnemies);
            _director.OnEnemies?.Invoke(localMeleeEnemies);
        }
    }

    public GameObject GetRangeEnemiesPooledObject()
    {
        for (int i = 0; i < _rangeEnemies.Count; i++)
        {
            if (!_rangeEnemies[i].activeInHierarchy)
            {
                return _rangeEnemies[i];
            }

        }

        return null;
    }

    public void RemoveRangeEnemiesPooledObject(GameObject localRangeEnemies)
    {
        if (localRangeEnemies != null)
        {
            localRangeEnemies.GetComponent<Stats>().OnHealth?.Invoke();
            _rangeEnemies.Remove(localRangeEnemies);
        }
    }

    public void AddRangeEnemiesPooledObject(GameObject localRangeEnemies)
    {
        if (localRangeEnemies != null)
        {
            localRangeEnemies.SetActive(false);
            localRangeEnemies.gameObject.SetActive(false);
            _rangeEnemies.Add(localRangeEnemies);
        }
    }
    
    public GameObject GetMeleeEnemiesPooledObject()
    {
        for (int i = 0; i < _meleeEnemies.Count; i++)
        {
            if (!_meleeEnemies[i].activeInHierarchy)
            {
                return _meleeEnemies[i];
            }

        }

        return null;
    }

    public void RemoveMeleeEnemiesPooledObject(GameObject localMeleeEnemies)
    {
        if (localMeleeEnemies != null)
        {
            localMeleeEnemies.GetComponent<Stats>().OnHealth?.Invoke();
            _rangeEnemies.Remove(localMeleeEnemies);
        }
    }
    
    public void AddMeleeEnemiesPooledObject(GameObject localMeleeEnemies)
    {
        if (localMeleeEnemies != null)
        {
            localMeleeEnemies.SetActive(false);
            localMeleeEnemies.gameObject.SetActive(false);
            _rangeEnemies.Add(localMeleeEnemies);
        }
    }

    
}
