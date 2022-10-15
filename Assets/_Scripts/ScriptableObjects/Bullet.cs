using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Custom/Weapon system/Bullet",fileName = "Bullet Type X", order =2)]
public class Bullet : ScriptableObject
{
    public int bulletDamage;
    public float bulletSpeed;
    public float bulletDistance;
    public GameObject BulletModel;
}