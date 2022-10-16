using UnityEngine;

/// <summary>
/// Class that holds all the Player character information
/// </summary>
public class PlayerCharacter : BaseCharacter
{
    public PlayerCharacter(int maxHP,int curHp, bool isAlive, float startSpeed, int pWorth, Weapon weapon)
    {
        MaxHitPoints = maxHP;
        CurrrentHp = curHp;
        this.isAlive = isAlive;
        MovementSpeed = startSpeed;
        PWorth = pWorth;
        Weapon = weapon;
    }
}