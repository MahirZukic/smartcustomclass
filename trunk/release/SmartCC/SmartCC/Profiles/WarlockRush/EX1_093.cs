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