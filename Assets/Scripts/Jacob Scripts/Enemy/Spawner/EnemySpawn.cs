using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float cooldown;

    private float spawnTime;

    public int totalSpawns;

    private int numSpawns;

    [SerializeField] private List<Transform> spawnTransforms = new List<Transform>();

    public float spawnPlayerDetectionRange;
  
    public LayerMask layerMask;

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
        
        int randEnemy  = Random.Range(1, 100);
      
        int randSpawn = Random.Range(0, spawnTransforms.Count);
      
        Collider2D col = Physics2D.OverlapCircle(spawnTransforms[randSpawn].position, spawnPlayerDetectionRange, layerMask);

        if (col)
        {
            if (randEnemy >= 1 && randEnemy <= 50)
            {
                GameObject rangeEnemies = EnemyObjectPool.Instance.GetRangeEnemiesPooledObject();
                rangeEnemies.transform.position = spawnTransforms[randSpawn].position;
                rangeEnemies.SetActive(true);
                EnemyObjectPool.Instance.RemoveRangeEnemiesPooledObject(rangeEnemies);
            }
            
            if (randEnemy >= 51 && randEnemy <= 100)
            {
                GameObject meleeEnemies = EnemyObjectPool.Instance.GetMeleeEnemiesPooledObject();
                meleeEnemies.transform.position = spawnTransforms[randSpawn].position;
                meleeEnemies.SetActive(true);
                EnemyObjectPool.Instance.RemoveMeleeEnemiesPooledObject(meleeEnemies);
            }
            
        }
        
    }
}
