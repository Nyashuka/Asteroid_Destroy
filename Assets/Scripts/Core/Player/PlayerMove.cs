using Assets.Scripts.Core.Player.UserInput;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private ScreenBoundary _boundary;

    private Camera _mainCamera;

    private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;

    private IUserInput _userInput;

    private void Start()
    {
        _mainCamera = Camera.main;

#if UNITY_ANDROID
        _userInput = new AndroidUserInput();
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        _userInput = new PCUserInput();
#endif

        _userInput.MoveEvent += MovePlayer;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        _userInput.Update();
    }

    private void MovePlayer(Vector3 pressedPosition)
    {
        pressedPosition.y = transform.position.y;
        pressedPosition.z += 1f;

        pressedPosition.z = Mathf.Clamp(pressedPosition.z, _boundary.zMin, _boundary.zMax);
        pressedPosition.x = Mathf.Clamp(pressedPosition.x, _boundary.xMin, _boundary.xMax);

        transform.position = Vector3.MoveTowards(transform.position, pressedPosition, _speed * Time.deltaTime);
    }
}
