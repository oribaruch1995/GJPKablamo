using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageDealer : MonoBehaviour, IObservable<int>
{
    public List<LayerMask> layers;
    public int Damage;
    private List<IObserver<int>> observers;

    public DamageDealer(int damage)
    {
        Damage = damage;
    }

    private void OnEnable()
    {
        Blackboard.EventManager?.Subscribe(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (layers.Contains(collision.gameObject.layer))
        {
            //TODO: Raise event for dealing dmg
            foreach(IObserver<int> observer in observers)
            {
                observer?.OnNext(Damage);
            }
        }
        Destroy(this.gameObject);
    }

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
        return new Unsubscriber(observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<int>> _observers;
        private IObserver<int> _observer;

        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
