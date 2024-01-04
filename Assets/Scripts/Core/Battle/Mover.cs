using Core.Pause;
using Core.Services.ServiceLocatorSystem;
using UnityEngine;

namespace Core.Battle
{
    public class Mover : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private float speed;
        private bool _isPaused = false;

        public void Start()
        {
            ServiceLocator.Instance.GetService<PauseManager>().Register(this);
        }

        private void Update()
        {
            if (_isPaused)
                return;

            transform.Translate(0,0, speed * Time.deltaTime);
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}
