using UnityEngine;

namespace Assets.Scripts.Services.ServiceLocator
{
    public abstract class MonoService : MonoBehaviour, IService
    {
        protected void Rename()
        {
            name = GetType().Name;
        }
    }
}
