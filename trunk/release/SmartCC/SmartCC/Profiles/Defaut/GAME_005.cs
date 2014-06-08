using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//The Coin

namespace HREngine.Bots
{
	[Serializable]
    public class bGAME_005 : Behavior
    {
		public bGAME_005() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            foreach(Card c in board.Hand)
            {
                if (c.CurrentCost == board.ManaAvailable + 1)
                    return true;
            }

            return false;
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
			return 100;
		}

        public override int GetHandValue(Board board)
		{
			return 3;
		}
		
    }
}
