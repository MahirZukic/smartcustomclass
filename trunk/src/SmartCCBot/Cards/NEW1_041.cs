using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Stampeding $
namespace HREngine.Bots
{
    [Serializable]
    public class NEW1_041 : Card
    {
        public override Card Create()
        { return new NEW1_041(); }
        public NEW1_041()
            : base()
        {

        }

        public NEW1_041(CardTemplate newTemplate, bool isFriend, int id)
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

            List<Card> targets = new List<Card>();
            foreach (Card c in board.MinionEnemy)
            {
                if (c.CurrentAtk <= 2)
                    targets.Add(c);
            }
            Card worstTarget = null;
            foreach (Card c in targets)
            {
                if (worstTarget == null)
                    worstTarget = c;
                if (worstTarget.GetValue(board) > c.GetValue(board))
                    worstTarget = c;
            }
            if (worstTarget != null)
                board.RemoveCardFromBoard(worstTarget.Id);

            board.Resimulate();
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
