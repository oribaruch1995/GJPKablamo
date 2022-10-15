using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStage currentStage;
    public List<Ceiling> ceilings;
    private void Awake()
    {
        Blackboard.GameManager = this;
        currentStage = GameStage.X;
    }
    private void Start()
    {
        currentStage = GameStage.A;
    }
    /// <summary>
    /// Change the stages visibility based on player position 
    /// </summary>
    /// <param name="stage"></param>
    public void ChangeStage(GameStage stage)
    {
        currentStage = stage;
        foreach(Ceiling c in ceilings)
        {
            c.TurnVisible(true);
            if ((currentStage == c.gameStage)) c.TurnVisible(false);
        }
    }

}
public enum GameStage
{
    X = 0,A =1, B = 2, ENDLESS = 42
}

