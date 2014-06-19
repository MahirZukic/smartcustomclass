using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Tundra Rhino
namespace HREngine.Bots
{
    [Serializable]
    public class DS1_178 : Card
    {
        public override Card Create()
        { return new DS1_178(); }
        public DS1_178()
            : base()
        {

        }

        public DS1_178(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
            IsCharge = true;
        }

        public override void OnPlay(ref Board board, Card target = null, int index = 0, int choice = 0)
        {
            base.OnPlay(ref board, target, index);
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
            foreach (Card c in board.MinionFriend)
            {
                if (c.Race == CRace.BEAST)
                    c.IsCharge = false;
            }
        }

        public override void OnPlayOtherMinion(ref Board board, ref Card Minion)
        {
            base.OnPlayOtherMinion(ref board, ref Minion);
            if (Minion.Race == CRace.BEAST && Minion.IsFriend == IsFriend)
                Minion.IsCharge = true;
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
            base.OnCastSpell(ref board, Spell);
        }


    }
}
