using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Waves/WaveData")]
public class WaveData : ScriptableObject
{
    public string waveName;
    public List<EnemySpawnData> enemies;
    [SerializeField]
    public ISpawnStrategy spawnStrategy = new InstantSpawnStrategy();
    public Vector3 spawnpoint;

    [System.Serializable]
    public class EnemySpawnData
    {
        public string enemyType; // Matches with EnemyFactory keys
        public int count;
    }
}
