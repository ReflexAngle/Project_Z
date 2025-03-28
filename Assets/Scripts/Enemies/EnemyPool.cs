using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPool : MonoBehaviour
{
    public EnemyPool Instance { get; private set; }

    [System.Serializable]
    public struct EnemyType
    {
        public string name;
        public GameObject prefab;
    }

    [SerializeField] private List<EnemyType> enemyTypes = new List<EnemyType>();
    [SerializeField] public int poolSize;
    
    private Dictionary<string, Queue<GameObject>> enemyPools = new Dictionary<string, Queue<GameObject>>();



    private void Awake()
    {
        Instance = this;

        InitializePools();
    }

    public void InitializePools()
    {
        foreach (EnemyType enemyType in enemyTypes)
        {
            Queue<GameObject> enemies = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject enemy = Instantiate(enemyType.prefab, this.transform);
                enemy.SetActive(false);

                // Attach EnemyTypeComponent and set the enemy type
                EnemyTypeComponent typeComponent = enemy.AddComponent<EnemyTypeComponent>();
                typeComponent.enemyType = enemyType.name;

                enemies.Enqueue(enemy);
            }

            enemyPools[enemyType.name] = enemies;
        }
    }

    public GameObject GetEnemy(string type, Vector3 spawnPosition)
    {
        Debug.Log("Try Getenemy" + type);
        //If there is no pool for the enemy type
        if (!enemyPools.ContainsKey(type))
        {
            Debug.LogError("No pool for enemy type: " + type);
            return null;
        }

        //If the pool is empty
        if (enemyPools[type].Count == 0)
        {
            Debug.LogWarning("Pool for enemy type: " + type + " is empty. Creating new enemy");
            foreach (EnemyType enemyType in enemyTypes)
            {
                if (enemyType.name == type)
                {
                    GameObject extraEnemy = Instantiate(enemyType.prefab, this.transform);
                    extraEnemy.SetActive(false);
                    enemyPools[type].Enqueue(extraEnemy);
                    break;
                }
            }

        }

        GameObject enemy = enemyPools[type].Dequeue();
        enemy.SetActive(true);
        enemy.transform.position = spawnPosition;
        return enemy;
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);

        // Get the enemy type from the EnemyTypeComponent
        EnemyTypeComponent typeComponent = enemy.GetComponent<EnemyTypeComponent>();
        if (typeComponent != null)
        {
            string type = typeComponent.enemyType;
            if (enemyPools.ContainsKey(type))
            {
                enemyPools[type].Enqueue(enemy);
            }
            else
            {
                Debug.LogError("No pool for enemy type: " + type);
            }
        }
        else
        {
            Debug.LogError("EnemyTypeComponent not found on enemy: " + enemy.name);
        }
    }

}
