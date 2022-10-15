using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
public abstract class BaseGameEvent<TData> : ScriptableObject
{
    protected List<IEventListener<TData>> listeners = new List<IEventListener<TData>>();

    public virtual void Raise(TData data)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(data);
    }

    public virtual void RegisterListener(IEventListener<TData> listener)
    { listeners.Add(listener); }

    public virtual void UnregisterListener(IEventListener<TData> listener)
    { listeners.Remove(listener); }
}
