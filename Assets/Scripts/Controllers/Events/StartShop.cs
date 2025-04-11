using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShop : IEvent
{

    [SerializeField]
    public GameObject shopText;
    public void StartEvent()
    {
        if (shopText == null)
        {
            Debug.LogError("Shop not set in StartShop");
        }
        else
        {
            shopText.SetActive(true);
        }
    }
    public void EndEvent()
    {
        // Implement any cleanup or end logic here if needed
        Debug.Log("Ending shop");
        if (shopText != null)
        {
            shopText.SetActive(false);
        }
    }
}
