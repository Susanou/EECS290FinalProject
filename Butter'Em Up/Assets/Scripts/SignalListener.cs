using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {
        Debug.Log("was raised");
        signalEvent.Invoke();
    }

    private void OnEnable()
    {
        signal.registerListener(this);
    }

    private void OnDisable()
    {
        signal.deregisterLinstener(this);

    }
}
