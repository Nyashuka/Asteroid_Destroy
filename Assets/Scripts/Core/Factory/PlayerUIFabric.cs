using System.Threading.Tasks;
using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Core.PlayerComponents;
using Core.PlayersComponents;
using Core.PlayersComponents.Bonuses;
using Core.Score;
using Core.Services.ServiceLocatorSystem;
using Services;
using UIModule;
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

            PlayerHUD ui = prefabContainer.GameData.PlayerUIAssetReference;

            Object.Instantiate(ui, canvasTransform);
        }
    }
}
