using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base abstract class for all characters
/// </summary>
public abstract class BaseCharacter
{
    /// <summary>
    /// Character max HP
    /// </summary>
    public int MaxHitPoints { get; set; }
    public int CurrrentHp { get; set; }
    public bool isAlive { get; set; }
    /// <summary>
    /// Base speed holder
    /// </summary>
    public float MovementSpeed { get; set; }
    /// <summary>
    /// Characters worth in Points for score system
    /// </summary>
    public int PWorth { get; set; }
    /// <summary>
    /// Characters assigned weapon
    /// </summary>
    public Weapon Weapon { get; set; }

}
