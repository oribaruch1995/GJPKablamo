using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    public bool isVisible { get; private set; } = true;
    [SerializeField] GameObject ceiling;

    public void TurnVisible(bool visible)
    {
        isVisible = visible;
        ceiling.layer = visible ? 0 : 6;
    }
}
