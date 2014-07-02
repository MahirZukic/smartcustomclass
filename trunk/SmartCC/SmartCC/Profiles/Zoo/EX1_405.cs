using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Shieldbearer

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_405 : Behavior
    {
		public bEX1_405() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.TurnCount == 1)
			{
				foreach(Card c in board.Hand)
				{
					if(c.CurrentCost == 1 && c.template.Id != "EX1_405")
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
