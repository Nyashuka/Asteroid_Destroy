using UIModule;
using UnityEngine;

namespace DataStructures.Scriptable
{
    [CreateAssetMenu(fileName = "UIData", menuName = "ScriptableObjects/UIAssetReferencesScriptableObject")]
    public class UIAssetReferencesScriptableObject : ScriptableObject
    {
        [SerializeField] private UIController uiDocument;
        [SerializeField] private MainMenuUI mainMenu;
        
        public UIController UIDocument => uiDocument;
        public MainMenuUI MainMenu => mainMenu;
    }
}
