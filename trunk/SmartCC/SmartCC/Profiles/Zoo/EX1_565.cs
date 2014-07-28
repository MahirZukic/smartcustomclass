using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Flametongue Totem

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_565 : Behavior
    {
		public bEX1_565() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.MinionFriend.Count == 0)
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
		
    }
}
