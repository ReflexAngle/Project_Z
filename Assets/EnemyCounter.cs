using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounter : IObserver
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
    private int waveCount = 0;
    [SerializeField]
    private GameObject enemyCountText;
    [SerializeField]
    private GameObject defeatCountText;


    private void Start()
    {
        // Attach this observer to the subject

        enemyPoolInstance = enemyPool.Instance;

        enemyPoolInstance.Attach(this);

    }

    public override void OnNotify(string action)
    {
        // Handle the notification from the subject  
        if (action == "EnemySpawned")
        {
            Debug.Log("An enemy has spawned!");
            enemySpawnCount++;
        }
        else if (action == "EnemyDefeated")
        {
            defeatedCount++;
            Debug.Log("An enemy has been defeated! Number " + defeatedCount);
        }
        else if (action == "WaveStarted")
        {
            Debug.Log("A new wave has started!");
            waveCount++;
        }
        else if (action == "WaveEnded")
        {
            Debug.Log("The wave has ended!");
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

}
