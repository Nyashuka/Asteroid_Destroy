using System.Threading.Tasks;
using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Core.Score;
using Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Factory
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

            Object.Instantiate(ui, canvasTransform);
        }
    }
}
