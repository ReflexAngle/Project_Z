using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObserver : MonoBehaviour
{
    public virtual void OnNotify(string action)
    {
        Debug.Log("Observer notified with action: " + action);
    }
}
