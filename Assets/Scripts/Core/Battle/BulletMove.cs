using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;

    private void Update()
    {
        if (IsPaused)
            return;

        transform.Translate(0,0, _speed * Time.deltaTime);
    }
}
