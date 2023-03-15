using Assets.Scripts.Core.PlayersComponents.UserInput;
using Assets.Scripts.Core.Utils;
using UnityEngine;

public class PlayerMove 
{
    private float _speed = 5;
    private Transform _transform;
    private IUserInput _userInput;

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
    }

    public void Move()
    {
        _userInput.Update();
    }

    private void MovePlayer(Vector3 pressedPosition)
    {
        pressedPosition.y = _transform.position.y;
        pressedPosition.z += 1f;

        pressedPosition.z = Mathf.Clamp(pressedPosition.z, ScreenBoundary.Instance.zMin, ScreenBoundary.Instance.zMax);
        pressedPosition.x = Mathf.Clamp(pressedPosition.x, ScreenBoundary.Instance.xMin, ScreenBoundary.Instance.xMax);

        _transform.position = Vector3.MoveTowards(_transform.position, pressedPosition, _speed * Time.deltaTime);
    }
}
