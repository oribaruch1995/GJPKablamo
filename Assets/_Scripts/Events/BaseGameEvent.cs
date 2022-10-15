using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
public abstract class BaseGameEvent<TData> : ScriptableObject
{
    protected event Action<TData> _event;
    public virtual void Raise(TData data)
    {
        _event?.Invoke(data);
    }

    public virtual void RegisterEvent(Action<TData> response) => _event += response;

    public virtual void UnregisterEvent(Action<TData> response) => _event -= response;
}
