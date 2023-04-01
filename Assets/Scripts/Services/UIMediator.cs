using Assets.Scripts.Core.PlayersComponents.Bonuses;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Services
{
    public class UIMediator : MonoBehaviour, IService
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private BuffIndicator _buffIndicator;

        public void InitScoreView(Score score) => _scoreView.Init(score);
        public void InitHealthBar(Health playerHealth) => _healthBar.Init(playerHealth);
        public void AddBuff(Type type, Image image) => _buffIndicator.Add(type, image);
        public void RemoveBuff(Type type) => _buffIndicator.Remove(type);
    }
}
