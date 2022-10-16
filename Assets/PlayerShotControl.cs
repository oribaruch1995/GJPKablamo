using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShotControl : MonoBehaviour
{
    public float FireRate;
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private float _nextShotTimer;

    void Start()
    {
        _nextShotTimer = FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && _nextShotTimer <= 0)
        {
            Debug.Log("Fire");
            Instantiate(_playerBullet, GameObject.Find("FirePoint").transform.position, Quaternion.identity, GameObject.Find("Bullets").transform);
            _nextShotTimer = FireRate;

        }
        else
            _nextShotTimer -= Time.deltaTime;
    }
}
