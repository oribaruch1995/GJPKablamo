using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable 
{
    public bool isAlive { get; set; }

    /// <summary>
    /// Logic for hp reaches 0
    /// </summary>
    public void OnDeath();

    /// <summary>
    /// Hit system impementation method
    /// </summary>
    /// <param name="damage"></param>
    public void OnHit(int damage);
}
