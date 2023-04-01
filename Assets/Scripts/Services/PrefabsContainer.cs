using Assets.Scripts.Services.Scriptable;
using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class PrefabsContainer : MonoBehaviour, IService
    {
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        [SerializeField] private GameAssetRefferencesScriptableObject _gameData;

        public GameAssetRefferencesScriptableObject GameData => _gameData;
    }
}
