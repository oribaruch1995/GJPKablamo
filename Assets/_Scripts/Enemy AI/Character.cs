using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character 
{
    public int HitPoints;
    public bool IsAlive;
    public int PointsWorth;
    public GameObject CurrentWeaponType;// Change GameObject to Weapon type
    private float _baseMovementSpeed;
    public void KillMe()
    {
        Debug.Log("kill enemy");
    }
    public void GetHit(int bulletPower)
    {
        HitPoints -= bulletPower;
    }
    public float GetBaseSpeed()
    {
        return _baseMovementSpeed;
    }
}
