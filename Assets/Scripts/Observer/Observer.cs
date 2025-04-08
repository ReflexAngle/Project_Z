using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public void OnNotify(string action)
    {
        // Handle the notification from the subject
        Debug.Log("Observer notified of action: " + action);
    }
}
