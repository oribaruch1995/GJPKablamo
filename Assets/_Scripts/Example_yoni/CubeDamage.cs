using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDamage : MonoBehaviour, IDamagable
{
    [SerializeField] private float _hp = 10;
    [SerializeField] private CubeEvent _cubeDeath;
    [SerializeField] private Cube _cube;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        Debug.Log("cube hp: " + _hp);
        if( _hp < 1)
        {
            _cubeDeath.Raise(_cube);
        }
    }
}
