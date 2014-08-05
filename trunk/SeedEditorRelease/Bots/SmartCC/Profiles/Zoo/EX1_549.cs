using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Bestial Wrath

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_549 : Behavior
    {
		public bEX1_549() : base()
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
            if (target != null)
            {
                if (target.Race == Card.CRace.BEAST)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
