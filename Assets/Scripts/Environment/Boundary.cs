using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float xMin { get; private set; }
    public float xMax { get; private set; }
    public float zMin { get; private set; }
    public float zMax { get; private set; }

    [SerializeField] private float _xCorrection;
    [SerializeField] private float _zMaxCorrection;
    [SerializeField] private float _zMinCorrection;
    [SerializeField] private MeshRenderer _gameBoard;

    private void Start()
    {
        InitializeBoundary();
    }

    private void InitializeBoundary()
    {
        //zMax = _zMaxCorrection;
        //zMin = _zMinCorrection;

        float widthScreen = Screen.width;
        float heightScreen = Screen.height;

        zMax = Camera.main.orthographicSize - _zMaxCorrection;
        zMin = -Camera.main.orthographicSize + _zMinCorrection;

        if (widthScreen < heightScreen)
        {
            float x = widthScreen / heightScreen * Camera.main.orthographicSize;

            xMin = -x - _xCorrection;
            xMax = x + _xCorrection;
        }
        else
        {
            xMin = -_gameBoard.bounds.size.x / 2 - _xCorrection;
            xMax = _gameBoard.bounds.size.x / 2 + _xCorrection;
        }
    }
}
