using Assets.Scripts.Services;
using Better.Attributes.Runtime.Select;
using Core.PlayersComponents.Bonuses.Abstract;
using UnityEngine;

namespace Core.PlayerComponents.Bonuses
{
    public class BuffContainer : MonoBehaviour, IDestroyable
    {
        [Select] [SerializeReference] private BuffEffect _buff;

        public BuffEffect GetBuff()
        {
            Destroy(gameObject);
            return _buff;
        }
    }
}
