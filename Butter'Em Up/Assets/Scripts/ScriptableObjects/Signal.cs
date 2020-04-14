﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Signals/signal", order = 1)]
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void registerListener(SignalListener l)
    {
        listeners.Add(l);
    }

    public void deregisterLinstener(SignalListener l)
    {
        listeners.Remove(l);
    }

}