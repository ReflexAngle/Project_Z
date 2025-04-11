using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounter : Subject, IObserver
{
    [SerializeField]
    private EnemyPool enemyPool;
    [SerializeField]
    private EnemyPool enemyPoolInstance;
    [SerializeField]
    private int enemyCurrentCount = 0;
    [SerializeField]
    private int enemySpawnCount = 0;
    [SerializeField]
    private int defeatedCount = 0;

    [SerializeField]
    private GameObject enemyCountText;
    [SerializeField]
    private GameObject defeatCountText;
    [SerializeField]
    private bool isFighting = false;


    private void Start()
    {
        // Attach this observer to the subject

        enemyPoolInstance = enemyPool.Instance;

        enemyPoolInstance.Attach(this);

    }

    public void OnNotify(string action)
    {
        // Handle the notification from the subject  
        if (action == "EnemySpawned")
        {
            Debug.Log("An enemy has spawned!");
            enemySpawnCount++;
            if (isFighting == false)
            {
                isFighting = true;
                Notify("WaveStarted");
            }
        }
        else if (action == "EnemyDefeated")
        {
            defeatedCount++;
            Debug.Log("An enemy has been defeated! Number " + defeatedCount);

            if (defeatedCount >= enemySpawnCount)
            {
                Debug.Log("All enemies have been defeated!");
                Notify("WaveEnded");
            }
        }
        else
        {
            Debug.Log("Unknown action: " + action);
        }

        // Update the UI or perform other actions based on the notification
    }
    private void Update()
    {
        enemyCurrentCount = enemySpawnCount - defeatedCount;
        enemyCountText.GetComponent<TextMeshProUGUI>().text = "Enemies: " + enemyCurrentCount;
        defeatCountText.GetComponent<TextMeshProUGUI>().text = "Defeated: " + defeatedCount;
    }

    public void Reset()
    {
        enemyCurrentCount = 0;
        enemySpawnCount = 0;
        defeatedCount = 0;
        isFighting = false;
        enemyCountText.GetComponent<TextMeshProUGUI>().text = "Enemies: " + enemyCurrentCount;
        defeatCountText.GetComponent<TextMeshProUGUI>().text = "Defeated: " + defeatedCount;
    }
}
