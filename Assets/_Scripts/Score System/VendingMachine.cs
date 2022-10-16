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

    public void BuyHealth()
    {
        if (scoreManager.BuyMe(HealthPrice))
        {

        }
    }
}
