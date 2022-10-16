using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Restart()
    {
        StartCoroutine( ReloadScene());
    }
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
