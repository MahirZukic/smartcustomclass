using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Totemic Call

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_049 : Behavior
    {
		public bCS2_049() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            if (board.MinionFriend.Count > 6)
                return false;

            bool hasHealTotem = false;
            bool hasIncenTotem = false;
            bool hasSpellTotem = false;
            bool hasTauntTotem = false;

            foreach (Card c in board.MinionFriend)
            {
                if (c.template.Id == "CS2_052")
                    hasSpellTotem = true;
                if (c.template.Id == "CS2_051")
                    hasTauntTotem = true;
                if (c.template.Id == "NEW1_009")
                    hasHealTotem = true;
                if (c.template.Id == "CS2_050")
                    hasIncenTotem = true;
            }


            if (hasHealTotem && hasIncenTotem && hasSpellTotem && hasTauntTotem)
                return false;

            return true;
        }

        public override bool ShouldAttack(Board board)
        {
            return true;
        }

        public override bool ShouldAttackTarget(Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Card target)
        {
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 10;
        }
		
    }
}
