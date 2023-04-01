using Assets.Scripts.Core.PlayersComponents.Bonuses.Abstract;
using Assets.Scripts.Services;
using BetterAttributes.Runtime.Attributes.Select;
using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents.Bonuses
{
    public class BuffContainer : MonoBehaviour, IDestroyable
    {
        [SelectImplementation] [SerializeReference] private BuffEffect _buff;

        public BuffEffect GetBuff()
        {
            Destroy(gameObject);
            return _buff;
        }
    }
}
