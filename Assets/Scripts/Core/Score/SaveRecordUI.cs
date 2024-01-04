using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core.Score
{
    public class SaveRecordUI : MonoBehaviour
    {
        [SerializeField] private InputField usernameInputField;
        [SerializeField] private Button saveButton;
        [SerializeField] private Game game;

        private void Start()
        {
            usernameInputField.onValidateInput += delegate (string input, int charIndex, char addedChar) 
            { 
                return ValidateUsername(addedChar); 
            };

            saveButton.onClick.AddListener(Save);
        }

        private char ValidateUsername(char charToValidate)
        {
            if (charToValidate == ' ')
                return '\0';

            return charToValidate;
        }

        private void Save()
        {
            game.SaveRecord(usernameInputField.text);
        }
    }
}
