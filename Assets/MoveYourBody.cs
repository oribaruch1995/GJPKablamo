using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveYourBody : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldnPosition;
    public LayerMask layerstoHit;

    void Update()
    {
        screenPosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitData,100, layerstoHit))
            worldnPosition = hitData.point;
        transform.LookAt(worldnPosition);
    }

}
