using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField]
    public EnemyPool enemyPool;

    [SerializeField]
    public List<WaveData> waves;
    public int currentWaveEnemyIndex = 0;

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



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWave(WaveData wave)
    {

        

        Debug.Log("Starting wave " + wave.name);

        spawnStrategies[wave.spawnStrategyIndex].SpawnWave(wave, enemyPool);

    }

    public void Reset()
    {
        enemyPool.ReturnAllEnemies();
    }
}
