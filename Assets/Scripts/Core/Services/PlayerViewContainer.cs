using Core.PlayerComponents;
using Core.PlayersComponents.Bonuses;
using Core.Score;
using Core.Services.ServiceLocatorSystem;
using UnityEngine;

namespace Core.Services
{
    public class PlayerViewContainer : MonoBehaviour, IService
    {
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private BuffIndicator buffIndicator;
        
        public ScoreView ScoreView => scoreView;
        public HealthBar HealthBar => healthBar;
        public BuffIndicator BuffIndicator => buffIndicator;

        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }
    }
}