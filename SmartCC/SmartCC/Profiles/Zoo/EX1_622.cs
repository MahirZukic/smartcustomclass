using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Shadow Word: Death

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_622 : Behavior
    {
		public bEX1_622() : base()
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
            if (target.CurrentAtk > 4)
                return true;
            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
