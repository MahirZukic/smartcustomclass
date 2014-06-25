using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Holy Smite
namespace HREngine.Bots
{
    [Serializable]
    public class CS1_130 : Card
    {
        public override Card Create()
        { return new CS1_130(); }
        public CS1_130()
            : base()
        {

        }

        public CS1_130(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
            TargetTypeOnPlay = TargetType.BOTH_ENEMY;
        }

        public override void OnPlay(ref Board board, Card target = null, int index = 0, int choice = 0)
        {
            base.OnPlay(ref board, target, index);
            if (target != null)
            {
                target.Damage((2 + board.GetSpellPower()) * board.DamageFactor, ref board);
            }
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
        }

        public override void OnPlayOtherMinion(ref Board board, ref Card Minion)
        {
            base.OnPlayOtherMinion(ref board, ref Minion);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
            base.OnCastSpell(ref board, Spell);
        }


    }
}
