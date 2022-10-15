using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Void Event")]

public class VoidGameEvent : ScriptableObject
{
    protected List<IEventListener> listeners = new List<IEventListener>();

    public virtual void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised();
    }

    public virtual void RegisterListener(IEventListener listener)
    { listeners.Add(listener); }

    public virtual void UnregisterListener(IEventListener listener)
    { listeners.Remove(listener); }
}
