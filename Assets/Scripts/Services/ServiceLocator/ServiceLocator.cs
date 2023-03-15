using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services.ServiceLocator
{
    public class ServiceLocator : MonoBehaviour, IServiceLocator
    {
        private Dictionary<Type, IService> _services;

        private static ServiceLocator _locator = null;

        public static ServiceLocator Instance
        {
            get
            {
                return _locator;
            }
        }

        public void Awake()
        {
            if (_locator == null)
            {
                _locator = this;
            }
        }

        public T GetService<T>() where T : IService
        {
            Type type = typeof(T);

            IService value;

            if (!_services.TryGetValue(type, out value))
                throw new ArgumentException();

            return (T)value; 
        }

        public void Register<T>(T service) where T : IService
        {
            Type type = service.GetType();

            _services.Add(type, service);
        }

        public void UnRegister<T>(T service) where T : IService
        {
            Type type = service.GetType();

            if (!_services.Remove(type))
                throw new ArgumentException();
        }
    }
}
