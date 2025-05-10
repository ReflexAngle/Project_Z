using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IObserver
{
    [SerializeField]
    EnemyCounter enemyCounter;
    [SerializeField]
    public EnemySpawner enemySpawner;
    [SerializeField]
    List<IEvent> Events = new List<IEvent>();
    [SerializeField]
    public List<WaveData> Waves;
    [SerializeField]
    int curEventIndex = 0;
    [SerializeField]
    GameObject shopText;
    [SerializeField]
    EventCreator eventCreator;



    // Start is called before the first frame update
    void Start()
    {

        //Events.Add(new StartWave() { enemySpawner = enemySpawner, waveData = Waves[1] });
        //Events.Add(new StartShop() { shopText = shopText });

        if (enemyCounter == null)
        {
            enemyCounter = FindObjectOfType<EnemyCounter>();
        }

        enemyCounter.Attach(this);

        if (enemySpawner == null)
        {
            enemySpawner = FindObjectOfType<EnemySpawner>();
        }

        if (eventCreator == null)
        {
            Debug.LogError("EventCreator not set in GameController");
            eventCreator = FindObjectOfType<EventCreator>();
        }

        eventCreator.addEvents();

        if (Events == null || Events.Count == 0)
        {
            Debug.LogError("No events set in GameController");
        }

        curEventIndex = 0;
        Events[curEventIndex].StartEvent();

        //enemySpawner.StartWave(Waves[0]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEvent(IEvent newEvent)
    {
        Events.Add(newEvent);
    }

    public void OnNotify(string action)
    {
        if (action == "NextEvent")
        {
            Events[curEventIndex].EndEvent();
            curEventIndex++;
            if (curEventIndex >= Events.Count)
            {
                curEventIndex = 0;
                Debug.Log("All events completed!");
            }
            else
            {
                Debug.Log("Next event: " + Events[curEventIndex].GetType().Name);

                // Start the next event
                Events[curEventIndex].StartEvent();

            }
        }

        if (action == "Start")
        {
            Debug.Log("Game started!");
            Events[curEventIndex].StartEvent();
        }

        if (action == "WaveStarted")
        {
            Debug.Log("A new wave has started!");
        }
        else if (action == "WaveEnded")
        {
            Debug.Log("The wave has ended!");
            enemyCounter.Reset();
            OnNotify("NextEvent");
        }
    }
}
