using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Blood Knight

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_590 : Behavior
    {
		public bEX1_590() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int nbShieldsOnBoard = 0;
			foreach(Card c in board.MinionFriend)
			{
				if(c.IsDivineShield)
					nbShieldsOnBoard++;
			}
			foreach(Card c in board.MinionEnemy)
			{
				if(c.IsDivineShield)
					nbShieldsOnBoard++;
			}
			if(board.TurnCount < 4 && nbShieldsOnBoard == 0 && board.Hand.Count > 3)
				return false;
				
			foreach(Card c in board.Hand)
			{
				if(c.IsDivineShield && nbShieldsOnBoard == 0)
				{
					return false;
				}
			}		
				
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
		
    }
}
