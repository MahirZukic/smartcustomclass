using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Defender of Argus

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_093 : Behavior
    {
		public bEX1_093() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.MinionFriend.Count < 1)
			{
				if(board.Hand.Count >= 3)
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
		
		public override int GetMinionValue(Board board)
		{
			if(board.MinionFriend.Count < 2)
				return 4;
			
			return 0;
		}
    }
}
