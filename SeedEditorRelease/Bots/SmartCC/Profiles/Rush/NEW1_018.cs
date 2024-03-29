using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Bloodsail Raider

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_018 : Behavior
    {
		public bNEW1_018() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.WeaponFriend == null && board.HasWeaponInHand() && board.TurnCount < 2)
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
