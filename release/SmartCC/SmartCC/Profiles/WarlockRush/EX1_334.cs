using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Shadow Madness

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_334 : Behavior
    {
		public bEX1_334() : base()
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

        public override bool ShouldAttackTarget(Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Card target)
        {
            if (target.CurrentAtk < 4)
                return true;
            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
