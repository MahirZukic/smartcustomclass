using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Animal Companion

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_031 : Behavior
    {
		public bNEW1_031() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.MinionFriend.Count == 7)
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
		
		public override int GetHandValue(Board board)
		{
			return 0;
		}
    }
}
