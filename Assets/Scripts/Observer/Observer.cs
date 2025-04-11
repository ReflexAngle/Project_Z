using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public virtual void OnNotify(string action)
    {

    }
}
