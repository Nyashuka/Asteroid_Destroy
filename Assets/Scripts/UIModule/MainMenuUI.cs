using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class MainMenuUI : UIElement
    {
        [SerializeField] private Text maxScoreText;
        [SerializeField] private Button playButton;
        [SerializeField] private Button recordsButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button settingsButton;
        public event Action PlayButtonClicked;
        
        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Initialize()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }
        
        private void OnPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }

        private void OnDestroy()
        {
            PlayButtonClicked = null;
        }
    }
}