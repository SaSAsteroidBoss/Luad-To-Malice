using System.Collections.Generic;
using UnityEngine;
public class EnemyObjectPool : MonoBehaviour
{
    public static EnemyObjectPool Instance;

    private List<GameObject> _rangeEnemies = new List<GameObject>();

    [SerializeField] private int amountToPoolRangeEnemies = 20;

    [SerializeField] private GameObject rangeEnemiesPrefab;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }


        for (int i = 0; i < amountToPoolRangeEnemies; i++)
        {
            var localRangeEnemies = Instantiate(rangeEnemiesPrefab);
            localRangeEnemies.name = "Range Enemies" + " " + i;
            localRangeEnemies.gameObject.SetActive(false);
            _rangeEnemies.Add(localRangeEnemies);
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
            localRangeEnemies.GetComponent<Health>().SetHealth();
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
}
