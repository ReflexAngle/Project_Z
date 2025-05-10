using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EventCreator : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private List<StartWave> eventList;

    void Awake()
    {
        if (gameController == null)
        {
            gameController = FindObjectOfType<GameController>();
        }

        createEventList();
    }

    public void addEvents()
    {
        foreach (var evt in eventList)
        {
            gameController.AddEvent(evt);
        }
    }

    public void createEventList()
    {
        eventList = new List<StartWave>();

        for (int i = 0; i < gameController.Waves.Count; i++)
        {
            StartWave startWave = new StartWave();
            startWave.SetWaveData(gameController.Waves[i]);
            startWave.SetEnemySpawner(gameController.enemySpawner);
            eventList.Add(startWave);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
