using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMove : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Touch.TouchInput.started += Somth;
    }

    private void Somth(InputAction.CallbackContext obj)
    {
      
    }
}
