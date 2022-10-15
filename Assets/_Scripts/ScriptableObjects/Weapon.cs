using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Weapon system/Weapon", fileName = "Weapon Type X", order = 1)]
public class Weapon : ScriptableObject
{
    public string ID;
    public Bullet bulletType;
    /// <summary>
    /// Angle deviation from gun nozzle forward (0 for straight) (30 for cone with 15deg to left and 15 to righe cone)
    /// </summary>
    public float FireAngle;
    /// <summary>
    /// In rounds per second
    /// </summary>
    public float FireRate;
}