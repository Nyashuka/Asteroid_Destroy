using System;
using System.Collections.Generic;
using Assets.Scripts.Services.ServiceLocatorSystem;

namespace Services.ServiceLocatorSystem
{
    public class ServiceLocator : IServiceLocator
    {
        private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        private static ServiceLocator _locator = null;

        public static ServiceLocator Instance
        {
            get
            {
                if (_locator == null)
                    _locator = new ServiceLocator();

                return _locator;
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
