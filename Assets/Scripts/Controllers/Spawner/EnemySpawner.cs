using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    public EnemyPool enemyPool;

    [SerializeField]
    public WaveData currentWave;

    [SerializeField]
    public List<ISpawnStrategy> spawnStrategies = new List<ISpawnStrategy>
    {
        new InstantSpawnStrategy(),
        new RandomSpawnStrategy()
    };

    // Start is called before the first frame update
    void Start()
    {
        
        if (enemyPool == null)
        {
            Debug.LogError("Enemy Pool not set in EnemySpawner");
            enemyPool = FindObjectOfType<EnemyPool>();
        }

        if (currentWave == null)
        {
            Debug.LogError("Current wave not set in EnemySpawner");
            currentWave = new WaveData();
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (GetTotalEnemiesInCurrentWave() <= 0)
        {
            Debug.Log("Wave " + currentWave.name + " is complete");
            currentWave = null;
            Reset();
        }
    }

    public void StartWave(WaveData wave)
    {

        

        Debug.Log("Starting wave " + wave.name);

        currentWave = wave;

        spawnStrategies[wave.spawnStrategyIndex].SpawnWave(wave, enemyPool);

    }

    public WaveData GetCurrentWave()
    {
        return currentWave;
    }

    public int GetTotalEnemiesInWave(WaveData wave)
    {
        int totalEnemies = 0;
        for (int i = 0; i < wave.enemies.Count; i++)
        {
            totalEnemies += wave.enemies [i].count;
        }
        return totalEnemies;
    }

    public int GetTotalEnemiesInCurrentWave()
    {
        if (currentWave == null)
        {
            Debug.LogError("Current wave is null");
            return 0;
        }
        return GetTotalEnemiesInWave(currentWave);
    }


    public void Reset()
    {
        enemyPool.ReturnAllEnemies();
    }
}
