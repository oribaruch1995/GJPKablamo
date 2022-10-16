using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    //public Action<bool>
    public int CurrentPoints;
    private int tryPoints;

    public bool TryBuy(int buyPoints)
    {
        if ((buyPoints < 0) || buyPoints > CurrentPoints)
        {
            Debug.Log("Doesnt have enough mesos");
            //TODO: fail to buy logic
            return false;
        }
        else
        {
            tryPoints = CurrentPoints - buyPoints;

            return true;
        }
    }
}
