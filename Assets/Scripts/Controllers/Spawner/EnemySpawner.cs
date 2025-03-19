using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
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
        }


        StartWave(currentWaveEnemyIndex);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWave(int waveIndex)
    {

        if (waveIndex >= waves.Count)
        {
            Debug.LogError("Wave index out of bounds");
            return;
        }
        if (waveIndex < 0)
        {
            Debug.LogError("Wave index out of bounds");
            return;
        }
        if (waves[waveIndex] == null)
        {
            Debug.LogError("No Wave for index "+waveIndex+" found");
            return;
        }

        Debug.Log("Starting wave " + waveIndex);

        WaveData wave = waves[waveIndex];
        spawnStrategies[wave.spawnStrategyIndex].SpawnWave(wave, enemyPool);
        waveIndex++;
    }
}
