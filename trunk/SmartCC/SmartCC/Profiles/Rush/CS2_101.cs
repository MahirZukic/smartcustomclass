using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Reinforce

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_101 : Behavior
    {
		public bCS2_101() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            if (board.MinionFriend.Count > 6)
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
