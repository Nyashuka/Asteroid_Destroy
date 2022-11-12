using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private ScreenBoundary _boundary;

    private Camera _mainCamera;

    private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            MovePlayer(mousePosition);
            return;
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            Vector3 touchPosition = _mainCamera.ScreenToWorldPoint(touch.position);
            MovePlayer(touchPosition);
        }
    }

    private void MovePlayer(Vector3 pressedPosition)
    {
        pressedPosition.y = transform.position.y;
        pressedPosition.z += 1f;

        if(pressedPosition.z > _boundary.zMax)
        {
            pressedPosition.z = _boundary.zMax;
        }
        if(pressedPosition.z < _boundary.zMin)
        {
            pressedPosition.z = _boundary.zMin;
        }
        if(pressedPosition.x > _boundary.xMax)
        {
            pressedPosition.x = _boundary.xMax;
        }
        if (pressedPosition.x < _boundary.xMin)
        {
            pressedPosition.x = _boundary.xMin;
        }

        //if (pressedPosition.z <= _boundary.zMax && pressedPosition.z >= _boundary.zMin &&
        //    pressedPosition.x <= _boundary.xMax && pressedPosition.x >= _boundary.xMin)
        //{
        //    //transform.position = Vector3.MoveTowards(transform.position, pressedPosition, _speed);
        //}

        transform.position = Vector3.MoveTowards(transform.position, pressedPosition, _speed * Time.deltaTime);
    }
}
