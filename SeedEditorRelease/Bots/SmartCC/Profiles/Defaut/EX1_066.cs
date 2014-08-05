using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Acidic Swamp Ooze

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_066 : Behavior
    {
		public bEX1_066() : base()
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
			if(board.WeaponEnemy == null && board.TurnCount < 8)
				return 10;
				
			return 0;
		}
		
    }
}
