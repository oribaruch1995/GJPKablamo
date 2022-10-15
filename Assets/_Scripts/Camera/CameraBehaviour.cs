using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour,IEventListener
{
    [SerializeField] private CinemachineVirtualCamera _firstViewCamera; 
    [SerializeField] private CinemachineVirtualCamera _followCharacterCamera;
    [SerializeField] private VoidGameEvent _gameStarted;

    private void Awake()
    {
        _followCharacterCamera.gameObject.SetActive(false);
        _firstViewCamera.gameObject.SetActive(true);
    }

    public void OnEventRaised()
    {
        OnGameStarted();
    }

    public void OnGameStarted()
    {
        _followCharacterCamera.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _gameStarted.RegisterListener(this);
    }

    private void OnDisable()
    {
        _gameStarted.UnregisterListener(this);
    }

}