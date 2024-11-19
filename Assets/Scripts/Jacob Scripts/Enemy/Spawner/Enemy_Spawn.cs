using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public float cooldown;

    private float spawnTime;

    public int totalSpawns;

    private int numSpawns;

    public List<GameObject> enemyTypes = new List<GameObject>();

    [SerializeField] private List<Transform> spawnTransforms = new List<Transform>();



    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= cooldown && numSpawns < totalSpawns)
        {
            if (numSpawns != 1)
            {
                Spawn();
                numSpawns++;
                spawnTime = 0;
            }
        }
    }

    private void Spawn()
    {
        int rand = Random.Range(0, spawnTransforms.Count);
        
        GameObject enemiesPooledObject = EnemyObjectPool.Instance.GetRangeEnemiesPooledObject();
        enemiesPooledObject.transform.position = spawnTransforms[rand].position;
        enemiesPooledObject.SetActive(true);
        

    }
}
