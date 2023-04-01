using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Factory
{
    public class PlayerUIFabric : IService
    {
        private HealthBar _healthBar;
        private BuffIndicator _buffIndicator;
        private ScoreView _scoreView;

        public PlayerUIFabric()
        {
            ServiceLocator.Instance.Register(this);
        }

        public async Task Create(Transform canvasTransform)
        {
            PrefabsContainer prefabContainer = ServiceLocator.Instance.GetService<PrefabsContainer>();

            GameObject ui = await AddressablesLoader.LoadAsync<GameObject>(prefabContainer.GameData.PlayerUIAssetReference.AssetGUID);

            MonoBehaviour.Instantiate(ui, canvasTransform);
        }
    }
}
