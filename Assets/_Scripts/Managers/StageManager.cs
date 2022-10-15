using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameStage currentStage;
    public List<Ceiling> ceilings;

    [SerializeField] private StageEvent _stageEnter;

    private void Awake()
    {
        Blackboard.StageManager = this;
        currentStage = GameStage.X;
    }
    private void Start()
    {
        ChangeStage(GameStage.A);
    }

    private void OnEnable()
    {
        _stageEnter.RegisterEvent(ChangeStage);
    }

    private void OnDisable()
    {
        _stageEnter.UnregisterEvent(ChangeStage);
    }
    /// <summary>
    /// Change the stages visibility based on player position 
    /// </summary>
    /// <param name="stage"></param>
    public void ChangeStage(GameStage stage)
    {
        if (currentStage == stage)
        {
            return;
        }

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

