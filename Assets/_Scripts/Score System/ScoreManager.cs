using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Public Event to try buying stuff
    /// </summary>
    public UnityEvent<int> BuyEvent;
    /// <summary>
    /// Public Event notify if the purchase was successful or not
    /// </summary>
    public Action<bool> BuyStatus;
    /// <summary>
    /// Main Func to use for buying items and buffs
    /// </summary>
    public Func<int, bool> BuyMe;
    public int CurrentPoints;

    private void OnEnable()
    {
        BuyEvent.AddListener(BuySomething);
        BuyMe = TryBuy;
    }
    private void OnDisable()
    {
        BuyEvent.RemoveListener(BuySomething);
    }

    public void BuySomething(int points)
    {
        BuyStatus.Invoke(TryBuy(points));
    }
    /// <summary>
    /// Try to buy item with points
    /// </summary>
    /// <param name="buyPoints"></param>
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
            int tryPoints = CurrentPoints - buyPoints;
            CurrentPoints = tryPoints;
            tryPoints = 0;
            return true;
        }
    }
}
