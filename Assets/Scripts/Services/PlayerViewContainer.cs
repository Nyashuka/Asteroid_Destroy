using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Assets.Scripts.Services.ServiceLocatorSystem;
using Core.Score;
using UnityEngine;

namespace Services
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