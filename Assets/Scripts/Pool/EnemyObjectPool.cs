using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyObjectPool : MonoBehaviour
{

    public static EnemyObjectPool Instance;

    [SerializeField] private List<GameObject> rangeEnemies = new List<GameObject>();

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
            rangeEnemies.Add(localRangeEnemies);
        }
    }

    void Start()
    {

    }

    public GameObject GetRangeEnemiesPooledObject()
    {
        for (int i = 0; i < rangeEnemies.Count; i++)
        {
            if (!rangeEnemies[i].activeInHierarchy)
            {
                return rangeEnemies[i];
            }

        }

        return null;
    }

    public void RemoveRangeEnemiesPooledObject(GameObject localRangeEnemies)
    {
        if (localRangeEnemies != null)
        {
            rangeEnemies.Remove(localRangeEnemies);
        }
    }

    public void AddRangeEnemiesPooledObject(GameObject localRangeEnemies)
    {
        if (localRangeEnemies != null)
        {
            localRangeEnemies.SetActive(false);
            localRangeEnemies.gameObject.SetActive(false);
            rangeEnemies.Add(localRangeEnemies);
        }
    }
}
