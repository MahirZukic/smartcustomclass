using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mirror Image

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_027 : Behavior
    {
		public bCS2_027() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.HasCardInHand("NEW1_019"))
			{
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
		
    }
}
