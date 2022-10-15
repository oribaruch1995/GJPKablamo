using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StageEntrance : MonoBehaviour
{
    public GameStage Stage;

    [SerializeField] private StageEvent _onEnterStage;

    private void OnTriggerEnter(Collider other)
    {
        _onEnterStage.Raise(Stage);
    }

}