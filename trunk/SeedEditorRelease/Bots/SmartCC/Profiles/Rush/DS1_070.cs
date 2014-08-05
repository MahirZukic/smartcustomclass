using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Houndmaster

namespace HREngine.Bots
{
	[Serializable]
    public class bDS1_070 : Behavior
    {
		public bDS1_070() : base()
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

        public override bool ShouldAttackTarget(Board board,Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Board board,Card target)
        {
            if (target.Race != Card.CRace.BEAST)
                return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetMinionValue(Board board)
		{
			foreach(Card c in board.MinionFriend)
			{
				if(c.Race == Card.CRace.BEAST)
					return 0;
			}
			
			return 15;
		}
		
    }
}
