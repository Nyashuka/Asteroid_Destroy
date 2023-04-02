using UnityEngine.ResourceManagement.AsyncOperations;

namespace Services
{
    public class LoadedHandleData
    {
        public int CountOfRefferences { get; private set; }

        private readonly AsyncOperationHandle<UnityEngine.Object> _handle;

        public LoadedHandleData(AsyncOperationHandle<UnityEngine.Object> handle)
        {
            _handle = handle;
            CountOfRefferences = 1;
        }

        public AsyncOperationHandle<UnityEngine.Object> GetHandle()
        {
            return _handle;
        }
        

        public void IncreaseCountOfRefference()
        {
            CountOfRefferences++;
        }

        public void DecreaseCountOfRefference()
        {
            CountOfRefferences--;
        }
    }
}