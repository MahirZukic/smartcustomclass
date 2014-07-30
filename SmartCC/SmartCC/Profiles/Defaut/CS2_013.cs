using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Wild Growth

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_013 : Behavior
    {
		public bCS2_013() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.MaxMana > 7 && board.MaxMana < 10)
				return false;
				
			if(board.TurnCount == 1)
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
