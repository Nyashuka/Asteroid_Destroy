using Assets.Scripts.Core.Player.Bonuses.Abstract;
using BetterAttributes.Runtime.Attributes.Select;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class BuffContainer : MonoBehaviour
    {
        [SelectImplementation][SerializeReference] private BuffEffect _buff;
    }
}
