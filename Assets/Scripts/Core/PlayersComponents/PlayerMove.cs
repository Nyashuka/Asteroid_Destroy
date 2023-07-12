using Assets.Scripts.Core.PlayersComponents.UserInput;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Services.ServiceLocatorSystem;
using UnityEngine;
using Utils;

public class PlayerMove 
{
    private float _speed = 5;
    private Transform _transform;
    private IUserInput _userInput;
    private ScreenBoundary _screenBoundary;

    public PlayerMove(Transform transform, float speed)
    {
#if UNITY_ANDROID
        _userInput = new AndroidUserInput();
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        _userInput = new PCUserInput();
#endif
        _speed = speed;
        _transform = transform;
        _userInput.MoveEvent += MovePlayer;
        _screenBoundary = ServiceLocator.Instance.GetService<ScreenBoundary>();
    }

    public void Move()
    {
        _userInput.Update();
    }

    private void MovePlayer(Vector3 pressedPosition)
    {
        pressedPosition.y = _transform.position.y;
        pressedPosition.z += 1f;

        pressedPosition.z = Mathf.Clamp(pressedPosition.z, _screenBoundary.zMin, _screenBoundary.zMax);
        pressedPosition.x = Mathf.Clamp(pressedPosition.x, _screenBoundary.xMin, _screenBoundary.xMax);

        _transform.position = Vector3.MoveTowards(_transform.position, pressedPosition, _speed * Time.deltaTime);
    }
}
