using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System;

[RequireComponent(typeof(ThirdPersonController))]

/// <summary>
/// Behavioral class for Character control
/// </summary>
public class CharacterBehaviour : MonoBehaviour , IHittable
{
    #region Definitions of Player
    [SerializeField] private int MaxHP;
    private PlayerCharacter playerCharacter;
    /// <summary>
    /// Sprint speed nultiplier
    /// </summary>
    [SerializeField] private float sprintMult = 1.2f;
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private Weapon weapon;
    [SerializeField] private int bulletsRemaining;
    #endregion Definitions of Player
    public Transform ShootPosition;
    public GameObject Bullets;
    private float fireRate;
    private ThirdPersonController thirdPersonController = null;

    public bool isAlive { get => isAlive; private set { isAlive = value; } }

    private void Awake()
    {
        AwakeAssign();
    }

    private void Start()
    {
        PlayerDefinitions();
        Blackboard.EventManager.PlayerHit += OnHit;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Damage")) return;
        if(TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            OnHit(damageDealer.Damage);
        }       
    }
    private void PlayerDefinitions()
    {
        if(thirdPersonController is null)
        {
            Debug.LogError("There is no ThirdPersonContoller on player");
            return;
        }
        baseMoveSpeed = playerCharacter.MovementSpeed;
        thirdPersonController.MoveSpeed = playerCharacter.MovementSpeed;
        thirdPersonController.SprintSpeed = playerCharacter.MovementSpeed * sprintMult;
        fireRate = playerCharacter.Weapon.FireRate;
        bulletsRemaining = playerCharacter.Weapon.ClipSize;
    }

    private void AwakeAssign()
    {
        if (TryGetComponent<ThirdPersonController>(out ThirdPersonController tpc))
            thirdPersonController = tpc;
        playerCharacter = new PlayerCharacter(MaxHP,MaxHP,true,baseMoveSpeed,1,weapon);
    }

    /// <summary>
    /// Speedchange by value, send 0 to reset to base speed.
    /// </summary>
    /// <param name="value"></param>
    public void SpeedChange(float value)
    {
        switch (value)
        {
            case 0:
                thirdPersonController.MoveSpeed = baseMoveSpeed;
                thirdPersonController.SprintSpeed = baseMoveSpeed * sprintMult;
                break;
            default:
                thirdPersonController.MoveSpeed += value;
                thirdPersonController.SprintSpeed = thirdPersonController.MoveSpeed * sprintMult;
                break;
        }
    }

    public void FireRateChange(float value)
    {
        switch (value)
        {
            case 0:
                playerCharacter.Weapon.FireRate = fireRate;
                break;
            default:
                playerCharacter.Weapon.FireRate += value;
                break;
        }
    }

    /// <summary>
    /// Used for healing the player (Buff or Vending machine)
    /// </summary>
    /// <param name="value"></param>
    public void Heal(int value)
    {
        if (playerCharacter.CurHitPoints <= playerCharacter.MaxHitPoints)
        {
            if ((playerCharacter.CurHitPoints + value) > playerCharacter.MaxHitPoints)
                playerCharacter.CurHitPoints = playerCharacter.MaxHitPoints;
            else
                playerCharacter.CurHitPoints += value;
        }
        else playerCharacter.CurHitPoints = playerCharacter.MaxHitPoints;
    }

    public void AddAmmo(int value)
    {
        if (bulletsRemaining <= playerCharacter.Weapon.ClipSize)
        {
            if ((bulletsRemaining + value) > playerCharacter.Weapon.ClipSize)
                bulletsRemaining = playerCharacter.Weapon.ClipSize;
            else
                bulletsRemaining += value;
        }
        else bulletsRemaining = playerCharacter.Weapon.ClipSize;
    }

    public void Shoot()
    {
        //TODO: shooting
    }

    public void OnDeath()
    {
        Blackboard.EventManager.PlayerHit -= OnHit;
        isAlive = false;
        //TODO: death logic
    }
    
    public void OnHit(int damage)
    {
        //TODO: Implement getting hit timer?
        playerCharacter.CurHitPoints += damage;
        if ((playerCharacter.CurHitPoints <= 0) && (isAlive)) OnDeath();
    }
}
