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

			if(board.EnemyClass == Board.Class.ROGUE || board.EnemyClass == Board.Class.MAGE || board.EnemyClass == Board.Class.DRUID)
			{
				List<Card> playable = board.GetPlayables(Card.CType.MINION, 2,2);
				int drop1Playable = board.GetPlayables(Card.CType.MINION, 1,1).Count;
				bool has2Hp = false;
				
				foreach(Card c in playable)
				{
					if(c.CurrentHealth >= 2)
						has2Hp = true;
				}
				
				if(!has2Hp && drop1Playable < 2 && board.ManaAvailable == 1 && !board.HasCardInHand("EX1_169"))
					return false;
			}
			

			if(board.TurnCount > 3)
				return true;
				
			if(board.GetPlayables(Card.CType.SPELL, 2,2).Count > 0 && board.TurnCount == 1)
				return true;
			
			if(board.MinionEnemy.Count > 0 && board.GetPlayables(Card.CType.MINION, 2,2).Count > 0 && board.TurnCount == 1)
				return true;
			
			if(board.GetPlayables(Card.CType.MINION, 2,2).Count < 2 && board.TurnCount == 1 && board.GetPlayables(Card.CType.MINION, 1,1).Count == 0 && !board.HasCardInHand("EX1_169"))
				return false;
				
            foreach(Card c in board.Hand)
            {
                if (c.CurrentCost == board.ManaAvailable + 1)
                    return true;
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
			return 3;
		}
		
    }
}
