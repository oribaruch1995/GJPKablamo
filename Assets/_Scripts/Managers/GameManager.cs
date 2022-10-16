using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Blackboard.GameManager = this;
    }

    private void Start()
    {
        StartSettings();
    }

    private void StartSettings()
    {
        Blackboard.ScoreManager.CurrentPoints = 0;
    }
}
