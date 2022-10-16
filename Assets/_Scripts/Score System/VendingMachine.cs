using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VendingMachine : MonoBehaviour
{
    [SerializeField] private Collider collider;
    private ScoreManager scoreManager;
    [SerializeField] private int HealthPrice;
    [SerializeField] private int AmmoPrice;
    private CharacterBehaviour currentCharacter;

    private void Awake()
    {
        currentCharacter = FindObjectOfType<CharacterBehaviour>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(TryGetComponent<CharacterBehaviour>(out CharacterBehaviour cha))
        {
            currentCharacter = cha;
        }
    }
    private void Start()
    {
        scoreManager = Blackboard.ScoreManager is null? null: Blackboard.ScoreManager;
    }

    /// <summary>
    /// Method to buy health in the vending machine
    /// </summary>
    /// <param name="healAmount"></param>
    public void BuyHealth(int healAmount)
    {
        if (scoreManager.BuyMe(HealthPrice))
        {
            currentCharacter?.Heal(healAmount);
        }
    }

    /// <summary>
    /// Method to buy Ammo in the vending machine
    /// </summary>
    /// <param name="amount"></param>
    public void BuyAmmo(int amount)
    {
        if (scoreManager.BuyMe(AmmoPrice))
        {
            currentCharacter?.AddAmmo(amount);
        }
    }

}
