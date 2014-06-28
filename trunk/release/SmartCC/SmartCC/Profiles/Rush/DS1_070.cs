using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Houndmaster

namespace HREngine.Bots
{
	[Serializable]
    public class bDS1_070 : Behavior
    {
		public bDS1_070() : base()
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
            if (target.Race != Card.CRace.BEAST)
                return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
