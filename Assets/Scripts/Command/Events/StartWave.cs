using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : IEvent
{
    [SerializeField]
    public WaveData waveData;
    [SerializeField]
    public EnemySpawner enemySpawner;


    public void StartEvent()
    {

            Debug.Log("Starting wave " + waveData.name);
            enemySpawner.StartWave(waveData);
        
    }
    public void EndEvent()
    {
        Debug.Log("Ending wave " + waveData.name);
        enemySpawner.Reset();
    }

    public void SetWaveData(WaveData wave)
    {
        waveData = wave;
    }
    public void SetEnemySpawner(EnemySpawner spawner)
    {
        enemySpawner = spawner;
    }

}
