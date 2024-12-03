using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float cooldown;

    private float spawnTime;

    public int totalSpawns;

    private int numSpawns;

    public List<GameObject> enemyTypes = new List<GameObject>();

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
        
        int rand = Random.Range(0, spawnTransforms.Count);
        Collider2D col = Physics2D.OverlapCircle(spawnTransforms[rand].position, spawnPlayerDetectionRange, layerMask);
        if (col)
        {
            print("player in range for spawn");
            GameObject enemiesPooledObject = EnemyObjectPool.Instance.GetRangeEnemiesPooledObject();
            enemiesPooledObject.transform.position = spawnTransforms[rand].position;
            enemiesPooledObject.SetActive(true);
            EnemyObjectPool.Instance.RemoveRangeEnemiesPooledObject(enemiesPooledObject);
            
        }
        
          
       
        
            
       
        

    }
}
