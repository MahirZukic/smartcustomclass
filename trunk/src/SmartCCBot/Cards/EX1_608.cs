using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Sorcerer\'s Apprentice
namespace HREngine.Bots
{
    [Serializable]
    public class EX1_608 : Card
    {
        public override Card Create()
        { return new EX1_608(); }
        public EX1_608()
            : base()
        {

        }

        public EX1_608(CardTemplate newTemplate, bool isFriend, int id)
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
            foreach (Card c in board.Hand)
            {
                if (c.Type == CType.SPELL)
                    c.CurrentCost--;
            }
        }

        public override void OnDeath(ref Board board)
        {
            base.OnDeath(ref board);
            if(!IsSilenced)
            {
                foreach (Card c in board.Hand)
                {
                    if (c.Type == CType.SPELL)
                        c.CurrentCost++;
                }
            }
            
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