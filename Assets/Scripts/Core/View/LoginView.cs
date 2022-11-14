using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View
{
    public class LoginView : MonoBehaviour
    {
        [SerializeField] private InputField _usernameInputField;
        [SerializeField] private Button _loginButton;

        private void Start()
        {
            _usernameInputField.onValidateInput += delegate (string input, int charIndex, char addedChar) 
            { 
                return ValidateUsername(addedChar); 
            };
        }

        private char ValidateUsername(char charToValidate)
        {
            if (charToValidate == ' ')
                return '\0';

            return charToValidate;
        }
    }
}
