using Services.ServiceLocatorSystem;
using UnityEngine;

namespace Services
{
    public class CameraController : MonoBehaviour, IService
    {
        [SerializeField] private Camera mainCamera;
    }
}