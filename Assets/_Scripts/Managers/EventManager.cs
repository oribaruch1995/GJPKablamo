using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour , IObserver<int>
{
    private IDisposable unsubscriber;
    public Action<int> PlayerHit;
    public Action<int> ScoreUpdate;
    public virtual void Subscribe(IObservable<int> provider)
    {
        unsubscriber = provider.Subscribe(this);
    }

    private void Awake()
    {
        Blackboard.EventManager = this;
    }

    #region IObserver Implementation
    public void OnCompleted()
    {
#if UNITY_EDITOR
        Debug.Log("Player been hit");
#endif
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(int value)
    {
        PlayerHit?.Invoke(value);
    }
    #endregion
    private void OnDestroy()
    {
        unsubscriber.Dispose();
    }
}
