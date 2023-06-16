using Assets.Scripts.Core.GameLogic;
using Core.GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.UI
{
    public class SaveRecord : MonoBehaviour
    {
        [SerializeField] private GameObject _saveRecordPanel;
        [SerializeField] private InputField _usernameInputField;
        [SerializeField] private GameOld gameOld;
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
            gameOld.SaveRecord(_usernameInputField.text);
        }
    }
}
