using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class BuffIndicator : MonoBehaviour
    {
        [SerializeField]private GameObject _buffIndicatorPanel;
        private Dictionary<Type, Image> _buffs = new Dictionary<Type, Image>();

        public void Add(Type type, Image image)
        {
            _buffs.Add(type, Instantiate(image, _buffIndicatorPanel.transform));
        }

        public void Remove(Type type)
        {
            Image image = _buffs[type];

            _buffs.Remove(type);
            Destroy(image.gameObject);
        }
    }
}
