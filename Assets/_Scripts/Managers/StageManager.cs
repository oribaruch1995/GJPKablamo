using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<Stage> Stages = new List<Stage>();

    private Stage _currentStage;
    [SerializeField] private StageEvent _stageEnter;


    private void Awake()
    {
        Blackboard.StageManager = this;
    }
    private void Start()
    {
        _currentStage = Stages.FirstOrDefault(stage => stage.GameStage == GameStage.A);
        _currentStage.EnterStage();
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
    /// <param name="gameStage"></param>
    public void ChangeStage(GameStage gameStage)
    {
        if (_currentStage.GameStage == gameStage)
        {
            return;
        }

        _currentStage.ExitStage();
        _currentStage = Stages.FirstOrDefault(x => x.GameStage == gameStage);
        _currentStage.EnterStage();
    }

}
public enum GameStage
{
    X = 0,A =1, B = 2, ENDLESS = 42
}

