using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Waves/WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField]
    public string waveName;
    [SerializeField]
    public List<EnemySpawnData> enemies;
    [SerializeField]
    public int spawnStrategyIndex;
    [SerializeField]
    public Vector3 spawnpoint;

    [System.Serializable]
    public class EnemySpawnData
    {
        public string enemyType; // Matches with EnemyFactory keys
        public int count;
    }
}
