using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RandomSpawnStrategy : ISpawnStrategy
{
    public float maxSpawnRadius = 3;
    public float timeBetweenSpawns = 1;
    override public void SpawnWave(WaveData wave, EnemyPool pool)
    {
        base.SpawnWave(wave, pool);

        Debug.Log("Spawning wave " + wave.name);

        for (int i = 0; i < wave.enemies.Count; i++)
        {
            Spawn(wave.enemies[i].enemyType, wave.spawnpoint, pool, wave.enemies[i].count);
        }
    }

    public async void Spawn(string enemyType, Vector3 spawnpoint, EnemyPool pool, int count)
    {
        base.Spawn(enemyType, spawnpoint, pool, count);

        // Generate a random position within a circle


        for (int i = 0; i < count; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * maxSpawnRadius;
            Vector3 spawnPosition = new Vector3(spawnpoint.x + randomOffset.x, spawnpoint.y, spawnpoint.z + randomOffset.y);

            pool.GetEnemy(enemyType, spawnPosition);

            await Task.Delay((int)(2 * 1000));

        }

    }

}
