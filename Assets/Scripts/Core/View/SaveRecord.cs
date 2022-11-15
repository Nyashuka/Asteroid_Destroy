using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View
{
    public class SaveRecord : MonoBehaviour
    {
        [SerializeField] private GameObject _saveRecordPanel;
        [SerializeField] private InputField _usernameInputField;
        [SerializeField] private Score _score;
        [SerializeField] private Button _saveButton;

        private void Start()
        {
            _usernameInputField.onValidateInput += delegate (string input, int charIndex, char addedChar) 
            { 
                return ValidateUsername(addedChar); 
            };
            _saveButton.onClick.AddListener(Save);
        }

        private char ValidateUsername(char charToValidate)
        {
            if (charToValidate == ' ')
                return '\0';

            return charToValidate;
        }

        private void Save()
        {
            ServicesProvider.Instance.PlayerDataManager.SaveSomePlayer(_usernameInputField.text, _score.Value);
            _saveRecordPanel.SetActive(false);
        }
    }
}
