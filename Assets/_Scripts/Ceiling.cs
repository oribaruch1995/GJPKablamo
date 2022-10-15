using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    public GameStage gameStage;
    public bool isVisible = true;
    private GameObject ceiling;

    private void Awake()
    {
        ceiling = this.gameObject;
    }


    public void TurnVisible(bool visible)
    {
        isVisible = visible;
        ceiling.layer = visible ? 0 : 6;
    }
}
