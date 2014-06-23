using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Circle of Healing

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_621 : Behavior
    {
		public bEX1_621() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
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
            return 1;
        }
		
		public override int GetHandValue(Board board)
		{
			if(board.HasMinionOnBoard("CS2_181",true))
				return 2;
			else
				return 5;
		}
		
    }
}
