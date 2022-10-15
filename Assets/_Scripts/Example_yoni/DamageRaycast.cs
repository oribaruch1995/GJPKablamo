using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageRaycast : MonoBehaviour,IEventListener
{
    [SerializeField] private VoidGameEvent _pointerDown;
    [SerializeField] private int _damage = 1;
    public void OnEventRaised()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            if(hit.transform.gameObject.TryGetComponent<IDamagable>(out var damagable))
            {
                damagable.TakeDamage(_damage);
            }
        }
    }

    private void OnEnable()
    {
        _pointerDown.RegisterListener(this);
    }

    private void OnDisable()
    {
        _pointerDown.UnregisterListener(this);
    }

}
