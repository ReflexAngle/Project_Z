using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    public string name;
    public List<isEnemy> enemies = new List<isEnemy>();
    public List<Vector3> spawnpoints = new List<Vector3>();
    public ISpawnStrategy spawnStrategy;


    // Start is called before the first frame update
    void Start()
    {
        if (spawnStrategy == null)
        {
            Debug.LogError("Spawn Strategy not set in Wave");
        }
        if (enemies.Count == 0)
        {
            Debug.LogError("No enemies in wave");
        }
        if (spawnpoints.Count == 0)
        {
            Debug.LogError("No spawnpoints in wave");
        }
        if (enemies.Count != spawnpoints.Count)
        {
            Debug.LogError("Enemies and spawnpoints do not match in wave");
        }

    }

    public void StartWave(EnemyPool pool)
    {
        //spawnStrategy.SpawnWave(this, pool);
        
    }

    public Wave(string name, List<isEnemy> enemies, List<Vector3> spawnpoints, ISpawnStrategy spawnStrategy)
    {
        this.name = name;
        this.enemies = enemies;
        this.spawnpoints = spawnpoints;
        this.spawnStrategy = spawnStrategy;
    }

    public Wave()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
