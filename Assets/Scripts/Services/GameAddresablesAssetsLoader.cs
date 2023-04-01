using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Services
{
    public class GameAddresablesAssetsLoader : MonoBehaviour, IService
    {
        [SerializeField] private AssetReference _playerAssetRefference;

        private void Start () 
        {
            ServiceLocator.Instance.Register(this);

        }


    }
}
