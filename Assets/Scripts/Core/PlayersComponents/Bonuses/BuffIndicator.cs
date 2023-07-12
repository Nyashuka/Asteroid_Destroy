using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.PlayersComponents.Bonuses
{
    public class BuffIndicator : MonoBehaviour
    {
        [SerializeField] private Transform buffIndicatorTransform;
        private readonly Dictionary<Type, Image> _buffs = new Dictionary<Type, Image>();

        public void Add(Type type, Image image)
        {
            _buffs.Add(type, Instantiate(image, buffIndicatorTransform));
        }

        public void Remove(Type type)
        {
            Image image = _buffs[type];

            _buffs.Remove(type);
            Destroy(image.gameObject);
        }
    }
}
