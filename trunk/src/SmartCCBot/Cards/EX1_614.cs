using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Illidan Stormrage
namespace HREngine.Bots
{
    [Serializable]
    public class EX1_614 : Card
    {
        public override Card Create()
        { return new EX1_614(); }
        public EX1_614()
            : base()
        {

        }

        public EX1_614(CardTemplate newTemplate, bool isFriend, int id)
            : base(newTemplate, isFriend, id)
        {

        }

        public override void Init()
        {
            base.Init();
        }

        public override void OnPlay(ref Board board, Card target = null, int index = 0, int choice = 0)
        {
            base.OnPlay(ref board, target, index);
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
        }

        public override void OnPlayOtherMinion(ref Board board, ref Card Minion)
        {
            base.OnPlayOtherMinion(ref board, ref Minion);
            if (IsFriend && board.MinionFriend.Count < 7)
                board.AddCardToBoard("EX1_614t", true, -1, false);
        }

        public override void OnCastSpell(ref Board board, Card Spell)
        {
            base.OnCastSpell(ref board, Spell);
            if (IsFriend && board.MinionFriend.Count < 7)
                board.AddCardToBoard("EX1_614t", true, -1, false);
        }

    }
}
