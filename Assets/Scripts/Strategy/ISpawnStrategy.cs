using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISpawnStrategy
{

    virtual public void SpawnWave(WaveData wave, EnemyPool pool)
    {
        Debug.Log("Spawning wave "+wave);
    }


    virtual public void Spawn(string enemyType, Vector3 spawnpoint, EnemyPool pool, int count)
    {
        Debug.Log("Spawning enemy");
    }

}
