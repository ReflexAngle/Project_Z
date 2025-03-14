using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSpawnStrategy : ISpawnStrategy
{

    override public void SpawnWave(WaveData wave, EnemyPool pool)
    {
        base.SpawnWave(wave, pool);

        Debug.Log("Spawning wave " + wave.name);

        for (int i = 0; i < wave.enemies.Count; i++)
        {
            Spawn(wave.enemies[i].enemyType, wave.spawnpoint, pool, wave.enemies[i].count);
        }
    }

    override public void Spawn(string enemyType, Vector3 spawnpoint, EnemyPool pool, int count)
    {
        base.Spawn(enemyType, spawnpoint, pool, count);

        for (int i = 0; i < count; i++)
            pool.GetEnemy(enemyType, spawnpoint);

    }

}
