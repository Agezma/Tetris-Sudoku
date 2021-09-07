using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();
    
    public static EventManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    private void Update()
    {
        Debug.Log(eventDictionary.Count);
    }

    public void SubscribeEvent(string eventName, Action listener)
    {
        if (instance.eventDictionary.ContainsKey(eventName))
        {
            instance.eventDictionary[eventName] += listener;
        }
        else
        {
            instance.eventDictionary.Add(eventName, listener);
        }
    }

    public void UnsuscribeEvent(string eventName, Action listener)
    {
        if (instance.eventDictionary.ContainsKey(eventName))
        {
            instance.eventDictionary[eventName] -= listener;
        }
    }

    public void TriggerEvent(string eventName)
    {
        Action thisEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
