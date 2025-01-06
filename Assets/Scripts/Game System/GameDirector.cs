using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameDirector : MonoBehaviour
{ 
   
    public UnityAction <GameObject> OnEnemies;

    public float globalGameLvlInterval;
    
    [SerializeField]
    private double lastGlobalGameLvlInterval;
    
    public int globalGameLvl;

    public float globalGameTime;
    
    [SerializeField]
    private List<Stats> enemies = new List<Stats>();

    private void Awake()
    {
        OnEnemies += HandleEnemies;
    }

    void Start()
    {
        lastGlobalGameLvlInterval = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        globalGameTime =  Time.realtimeSinceStartup;
        
        if (globalGameTime > lastGlobalGameLvlInterval + globalGameLvlInterval)
        { 
            lastGlobalGameLvlInterval = globalGameTime;
           
            ++globalGameLvl;
            
            for (int i = 0; i < enemies.Count; ++i)
            {
                enemies[i].OnIncreaseStats?.Invoke(1, 5, 10);
            }
        }
    }

    private void HandleEnemies(GameObject localEnemies)
    {
        var armour = localEnemies.GetComponent<EnemyArmour>();
        var health = localEnemies.GetComponent<EnemyHealth>();
        var stats = localEnemies.GetComponent<Stats>();
        
        armour.Start();
        health.Start();
        stats.Start(); 
        
        enemies.Add(stats);
    }
}
