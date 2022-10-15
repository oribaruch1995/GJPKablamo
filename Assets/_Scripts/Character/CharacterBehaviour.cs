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
    [SerializeField] PlayerCharacter playerCharacter;
    /// <summary>
    /// Sprint speed nultiplier
    /// </summary>
    [SerializeField] private float sprintMult = 1.2f;
    [SerializeField] private float baseMoveSpeed;
    public Transform ShootPosition;
    private ThirdPersonController thirdPersonController = null;

    public bool isAlive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private void Awake()
    {
        AwakeAssign();
    }

    private void Start()
    {
        PlayerDefinitions();
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
    }

    private void AwakeAssign()
    {
        if (TryGetComponent<ThirdPersonController>(out ThirdPersonController tpc))
            thirdPersonController = tpc;
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
    public void Shoot()
    {

    }

    public void OnDeath()
    {
        isAlive = false;
    }
    
    public void OnHit(int damage)
    {
        playerCharacter.CurHitPoints += damage;
        if ((playerCharacter.CurHitPoints <= 0) && (isAlive)) OnDeath();
    }
}
