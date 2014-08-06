using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Flare

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_544 : Behavior
    {
		public bEX1_544() : base()
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
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetHandValue(Board board)
		{
			if((board.EnemyClass == Board.Class.MAGE || board.EnemyClass == Board.Class.HUNTER))
			{
				if(!board.SecretEnemy && board.EnemyCardCount >= 3)
					return 5;
				else
					return 0;
			}
			return 0;
		}
		
    }
}
