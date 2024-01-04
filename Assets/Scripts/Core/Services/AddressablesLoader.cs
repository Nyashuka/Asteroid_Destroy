using System.Collections.Generic;
using System.Threading.Tasks;
using Services;
using UnityEngine.AddressableAssets;

namespace Core.Services
{
    public static class AddressablesLoader
    {
        private static readonly Dictionary<string, LoadedHandleData> HandlesData = new Dictionary<string, LoadedHandleData>();

        public static async Task<T> LoadAsync<T>(string assetGuid) where T : UnityEngine.Object
        {
            if (!HandlesData.TryGetValue(assetGuid, out LoadedHandleData handleData))
            {
                var handle = Addressables.LoadAssetAsync<UnityEngine.Object>(assetGuid);
                LoadedHandleData data = new LoadedHandleData(handle);
                HandlesData.Add(assetGuid, data);
                return await HandlesData[assetGuid].GetHandle().Task as T;
            }

            HandlesData[assetGuid].IncreaseCountOfRefference();

            return await handleData.GetHandle().Task as T;
        }

        public static void UnloadAsset(string assetGuid)
        {
            if (HandlesData.TryGetValue(assetGuid, out LoadedHandleData handleData))
            {
                if (handleData.CountOfRefferences > 1)
                {
                   HandlesData[assetGuid].DecreaseCountOfRefference();
                }
                else
                {
                    HandlesData.Remove(assetGuid);
                    Addressables.Release(assetGuid);
                }
            }
        }
    }
}
