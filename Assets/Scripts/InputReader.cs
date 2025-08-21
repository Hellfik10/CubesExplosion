using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int CubeClickButtonCode = 0;

    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private CubeHandler _cubeHandler;

    private void Update()
    {
        if (Input.GetMouseButtonDown(CubeClickButtonCode))
        {
            _rayCaster.UpdateRaycastFromMouse();
        }
    }
}