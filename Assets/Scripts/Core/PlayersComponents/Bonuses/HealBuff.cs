using Assets.Scripts.Core.PlayersComponents.Bonuses.Abstract;

namespace Assets.Scripts.Core.PlayersComponents.Bonuses
{
    public class HealBuff : PermanentBuff, ISupportBuff
    {
        private IHealeable _healeableObject;

        public void Init(Player baffOwner)
        {
            _healeableObject = baffOwner;
        }

        public override void Apply()
        {
            _healeableObject.Heal();
            _buffIsEnded = true;
        }

    }
}
