using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.GameMenu
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _menuPanel;
        [SerializeField] private CanvasGroup _saveRecordPanel;
        [SerializeField] private CanvasGroup _gameOverText;

        [SerializeField] private CanvasGroup _resumeButton;
        [SerializeField] private CanvasGroup _restartButton;
        [SerializeField] private CanvasGroup _exitToMenuButton;
        [SerializeField] private CanvasGroup _pauseButton;
        [SerializeField] private CanvasGroup _openSaveRecordWindowButton;
        [SerializeField] private CanvasGroup _saveRecordButton;

        public void CloseSaveRecordWindow()
        {
            _saveRecordPanel.IsEnableCanvasGroup(false);
            _restartButton.IsEnableCanvasGroup(true);
            _saveRecordButton.IsEnableCanvasGroup(true);
            _exitToMenuButton.IsEnableCanvasGroup(true);
        }

        public void OpenSaveRecordWindow()
        {
            _saveRecordPanel.IsEnableCanvasGroup(true);
            _restartButton.IsEnableCanvasGroup(false);
            _saveRecordButton.IsEnableCanvasGroup(false);
            _exitToMenuButton.IsEnableCanvasGroup(false);
        }

        public void ShowPauseWindow()
        {
            ShowGeneral();
            _resumeButton.IsEnableCanvasGroup(true);
        }

        public void ClosePauseWindow()
        {
            _resumeButton.IsEnableCanvasGroup(false);
            HideGeneral();
        }

        public void ShowGameOverWindow()
        {
            ShowGeneral();
            _gameOverText.IsEnableCanvasGroup(true);
            _restartButton.IsEnableCanvasGroup(true);
            _saveRecordButton.IsEnableCanvasGroup(true);
        }

        private void ShowGeneral()
        {
            _menuPanel.IsEnableCanvasGroup(true);
            _exitToMenuButton.IsEnableCanvasGroup(true);
        }

        private void HideGeneral()
        {
            _menuPanel.IsEnableCanvasGroup(false);
            _exitToMenuButton.IsEnableCanvasGroup(false);
        }
    }
}
