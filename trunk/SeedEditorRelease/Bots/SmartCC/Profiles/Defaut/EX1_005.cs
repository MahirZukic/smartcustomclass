using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Big Game Hunter

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_005 : Behavior
    {
		public bEX1_005() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            foreach(Card c in board.MinionEnemy)
            {
                if (c.CurrentAtk >= 7)
                    return true;
            }

            if (board.Hand.Count > 1)
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
			if(target.CurrentAtk < 7)
				return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}