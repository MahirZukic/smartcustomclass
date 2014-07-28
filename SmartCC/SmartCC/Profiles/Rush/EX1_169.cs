using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Innervate

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_169 : Behavior
    {
		public bEX1_169() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {

			foreach(Card c in board.Hand)
			{
				if(c.CurrentCost == 4 && c.Type == Card.CType.MINION)
					if(board.TurnCount < 2 && !board.HasCardInHand("GAME_005"))
						return false;
			}
			
			
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
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetHandValue(Board board)
		{
		    if(board.TurnCount > 3)
				return 3;
			return 6;
		}
    }
}
