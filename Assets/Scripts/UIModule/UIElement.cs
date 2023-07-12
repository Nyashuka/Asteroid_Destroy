using System;
using UnityEngine;

namespace UIModule
{
    [Serializable]
    public abstract class UIElement : MonoBehaviour
    {
        public abstract void Show();

        public abstract void Initialize();
    }
}