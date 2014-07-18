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

			if(board.EnemyClass() == "rogue" || board.EnemyClass() == "mage" || board.EnemyClass() == "druid")
			{
				List<Card> playable = board.GetPlayables(Card.CType.MINION, 2,2);
				int drop1Playable = board.GetPlayables(Card.CType.MINION, 1,1).Count;
				bool has2Hp = false;
				
				foreach(Card c in playable)
				{
					if(c.CurrentHealth >= 2)
						has2Hp = true;
				}
				
				if(!has2Hp && drop1Playable < 2)
					return false;
			}
			

			if(board.TurnCount > 3)
				return true;
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
			return 1;
		}

        public override int GetHandValue(Board board)
		{
			return 3;
		}
		
    }
}
