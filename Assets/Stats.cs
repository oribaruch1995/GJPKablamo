using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Enemy enemy = new Enemy();
    private float movementSpeed;
    void Start()
    {
      enemy.HitPoints = 10;
      enemy.PointsWorth = 5;
      movementSpeed = enemy.GetBaseSpeed();
    }

}
