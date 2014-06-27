using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mortal Coil

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_302 : Behavior
    {
		public bEX1_302() : base()
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
            if (target.CurrentHealth == 1 || target.IsDivineShield )
                return true;
            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 2;
        }
		
    }
}
