using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private VoidGameEvent _pointerDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pointerDown.Raise();
        }
    }
}
