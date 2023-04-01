using UnityEngine;

namespace Assets.Scripts.Services.ServiceLocatorSystem
{
    public abstract class MonoService : MonoBehaviour, IService
    {
        protected void Rename()
        {
            name = GetType().Name;
        }
    }
}
