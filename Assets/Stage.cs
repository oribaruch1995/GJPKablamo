using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameStage GameStage;

    [SerializeField] private Ceiling _ceiling;
    public void EnterStage()
    {
        _ceiling.TurnVisible(false);
    }

    public void ExitStage()
    {
        _ceiling.TurnVisible(true);
    }
}
