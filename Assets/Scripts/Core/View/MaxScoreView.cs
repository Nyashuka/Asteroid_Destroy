

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.View
{
    public class MaxScoreView : MonoBehaviour
    {
        [SerializeField] private string _text;
        [SerializeField] private Text _textBox;

        public void Start()
        {
            _textBox.text = _text + " " + ServicesProvider.Instance.PlayerDataManager.CurrentPlayer.MaxScore;
        }
    }
}
