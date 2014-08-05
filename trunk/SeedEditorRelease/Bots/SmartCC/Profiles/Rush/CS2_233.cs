using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Blade Flurry

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_233 : Behavior
    {
		public bCS2_233() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            if (board.WeaponFriend == null)
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
			return 7;
		}
    }
}
