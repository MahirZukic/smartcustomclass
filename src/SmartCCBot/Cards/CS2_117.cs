using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Earthen Ring Farseer
namespace HREngine.Bots
{
    [Serializable]
    public class CS2_117 : Card
    {
        public override Card Create()
        { return new CS2_117(); }
        public CS2_117()
            : base()
        {

        }

        public CS2_117(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.BOTH_FRIEND;
        }

        public override void OnPlay(ref Board board, Card target = null, int index = 0, int choice = 0)
        {
            base.OnPlay(ref board, target, index);
            if (target != null)
            {
                target.Heal(3, ref board);
            }

        }


        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
        }

        public override void OnPlayOtherMinion(ref Board board, Card Minion)
        {
            base.OnPlayOtherMinion(ref board, Minion);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
            base.OnCastSpell(ref board, Spell);
        }


    }
}