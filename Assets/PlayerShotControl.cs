using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShotControl : MonoBehaviour
{
    public float FireRate;
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private float _nextShotTimer;
    private CharacterBehaviour _characterBehaviour;
    public AudioSource audiosource;
    public AudioClip shotSfx;

    private void OnEnable()
    {
        _characterBehaviour = GetComponent<CharacterBehaviour>();
    }
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
            var bullet = Instantiate(_playerBullet, GameObject.Find("FirePoint").transform.position, Quaternion.identity, GameObject.Find("Projectiles").transform)
                                .GetComponent<PlayerBullet>();
            audiosource.PlayOneShot(shotSfx);
            bullet.Damage = _characterBehaviour.weapon.bulletType.bulletDamage;
            _nextShotTimer = FireRate;

        }
        else
            _nextShotTimer -= Time.deltaTime;
    }
}
