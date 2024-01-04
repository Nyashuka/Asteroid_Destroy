namespace Core.Services.ServiceLocatorSystem
{
    public interface IServiceLocator
    {
        T GetService<T>() where T : IService;
        void Register<T>(T service) where T : IService;
        void UnRegister<T>(T service) where T : IService;
    }
}
