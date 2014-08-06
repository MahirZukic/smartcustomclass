using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Starving Buzzard

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_237 : Behavior
    {
		public bCS2_237() : base()
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
		
		public override int GetMinionValue(Board board)
		{
			if(board.GetCountInHand("EX1_538") > 0 && board.ManaAvailable >= 5)
				return 5;
			if(board.GetCountInHand("CS2_237") > 1)
				return 15;
			return 30;
		}
		
		
    }
}
