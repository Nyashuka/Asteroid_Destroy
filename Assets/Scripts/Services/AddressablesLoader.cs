using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Services
{
    public class LoadedHandleData
    {
        public int CountOfRefferences { get; private set; }

        private AsyncOperationHandle<UnityEngine.Object> _handle;

        public LoadedHandleData(AsyncOperationHandle<UnityEngine.Object> handle)
        {
            _handle = handle;
            CountOfRefferences = 1;
        }

        public AsyncOperationHandle<UnityEngine.Object> GetHandle()
        {
            return _handle;
        }

        public int GetCountOfRefferences()
        {
            return CountOfRefferences;
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

    public static class AddressablesLoader
    {
        private static readonly Dictionary<string, LoadedHandleData> _handlesData = new Dictionary<string, LoadedHandleData>();

        public static async Task<T> LoadAsync<T>(string assetGUID) where T : UnityEngine.Object
        {
            if (!_handlesData.TryGetValue(assetGUID, out LoadedHandleData handleData))
            {
                var handle = Addressables.LoadAssetAsync<UnityEngine.Object>(assetGUID);
                LoadedHandleData data = new LoadedHandleData(handle);
                _handlesData.Add(assetGUID, data);
                return await _handlesData[assetGUID].GetHandle().Task as T;
            }

            _handlesData[assetGUID].IncreaseCountOfRefference();

            return await handleData.GetHandle().Task as T;
        }

        public static void UnloadAsset(string assetGUID)
        {
            if (_handlesData.TryGetValue(assetGUID, out LoadedHandleData handleData))
            {
                if (handleData.CountOfRefferences > 1)
                {
                   _handlesData[assetGUID].DecreaseCountOfRefference();
                }
                else
                {
                    _handlesData.Remove(assetGUID);
                    Addressables.Release(assetGUID);
                }
            }
        }
    }
}
