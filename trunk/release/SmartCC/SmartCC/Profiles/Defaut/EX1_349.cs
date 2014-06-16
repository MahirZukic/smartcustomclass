using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Divine Favor

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_349 : Behavior
    {
		public bEX1_349() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.EnemyCardCount - board.Hand.Count > 2)
				return false;
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
