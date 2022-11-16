using Assets.Scripts.Core.Player.Bonuses.Abstract;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class HealBuff : PermanentBuff, ISupportBuff
    {
        private IHealeable _healeableObject;

        public override void Init(Player baffOwner)
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
