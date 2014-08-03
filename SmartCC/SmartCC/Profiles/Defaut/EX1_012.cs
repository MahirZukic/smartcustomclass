using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Bloodmage Thalnos

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_012 : Behavior
    {
		public bEX1_012() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
		    bool enemyHas2Hp = false;
			
			foreach(Card c in board.MinionEnemy)
			{
				if(c.CurrentHealth == 2)
				{
					enemyHas2Hp = true;
					break;
				}
			}
			
			bool hasInnerRage = board.HasCardInHand("EX1_607");
			if(board.TurnCount < 3 && !(enemyHas2Hp && hasInnerRage))
				return false;
				
			if(board.TurnCount <= 2)
				return false;
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
		
		public override int GetPriorityAttack(Board board)
        {
            return 2;
        }
		
		public override int GetMinionValue(Board board)
		{
			return 20;
		}
		
    }
}
