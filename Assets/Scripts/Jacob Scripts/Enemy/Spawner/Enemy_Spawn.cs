using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public float cooldown;

    private float spawnTime;

    public int totalSpawns;

    private int numSpawns;

    public List<GameObject> enemyTypes = new List<GameObject>();



    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= cooldown && numSpawns < totalSpawns)
        {
            Spawn();
            numSpawns++;
            spawnTime = 0;
        }
    }

    private void Spawn()
    {
        int index = Random.Range(0, enemyTypes.Count - 1);
        Instantiate(enemyTypes[index]);
    }
}