using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Subject : MonoBehaviour
{
    private List<Observer> observers = new List<Observer>();

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    protected void Notify(string action)
    {
        foreach (Observer observer in observers)
        {
            observer.OnNotify(action);
        }
    }
}
